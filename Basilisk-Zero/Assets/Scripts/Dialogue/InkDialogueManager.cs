using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float textSpeed = 0.16f;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public Story currentStory;
    // Flag to check if dialogue is playing or not (to prevent player from moving) 
    public bool dialogueIsPlaying { get; private set; }
    private bool canContinueLine = false;
    private Coroutine displayLineCoroutine;
    private static InkDialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";

    private InkDialogueVariables dialogueVariables;
    private InkExternalFunctions inkExternalFunctions;

    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }

        dialogueVariables = new InkDialogueVariables(loadGlobalsJSON);
        inkExternalFunctions = new InkExternalFunctions();
    }

    public static InkDialogueManager GetInstance()
    {
        return instance;
    }

    private void Start() 
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices) {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
            return;
        
        if (canContinueLine && currentStory.currentChoices.Count == 0 && Input.GetButtonUp("Submit"))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);
        //inkExternalFunctions.Bind(currentStory);

        // reset dialogue tags
        displayNameText.text = "???";
        portraitAnimator.Play("default");
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);
        //inkExternalFunctions.Unbind(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        // Next line the dialogue
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            string nextLine = currentStory.Continue();
            // handle case where the Last Line is an external function
            if (nextLine.Equals("") && !currentStory.canContinue)
            {
                StartCoroutine(ExitDialogueMode());
            }
            else //Otherwise play story as normal
            {
                HandleTags(currentStory.currentTags); // code for handling tags
                displayLineCoroutine = StartCoroutine(DisplayLine(nextLine));
            }
            
            
            
        } else {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        // Reset text box and hide UI elements
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;
        continueIcon.SetActive(false);
        HideChoices();
        
        canContinueLine = false;
        
        foreach (char letter in line.ToCharArray())
        {
            // If "Enter" button pressed then display whole line
            if (Input.GetButtonUp("Submit"))
            {
                dialogueText.maxVisibleCharacters = line.Length;
                break;
            }

            dialogueText.maxVisibleCharacters += 1;
            yield return new WaitForSeconds(textSpeed);
        }

        // Make dialogue able to display next line
        continueIcon.SetActive(true);
        DisplayChoices();

        canContinueLine = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    // Parses each tag in an ink file and appropiately changes aspects in the dialogue bubbles
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags) 
        {
            // Split tag that looks like 'speaker:Dawn' for example
            string[] splitTag = tag.Split(":");
            if  (splitTag.Length != 2)
            {
                Debug.LogError("Tag was not properly parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogError("Tag is not the kind that is being handled: " + tag);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //Make sure UI can handle amount of choices
        if (currentChoices.Count > choices.Length) 
        {
            Debug.LogError("More choices than UI can handle. Number of choices: " + currentChoices.Count);
        }

        int i = 0;
        // Get choices from story
        foreach (Choice choice in currentChoices)
        {
            choices[i].gameObject.SetActive(true);
            choicesText[i].text = choice.text;
            i++;
        }

        // Hide remaining choices
        for (int j = i; j < choices.Length; j++) 
        {
            choices[j].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event system needs to be cleared and then wait for one frame
        // before selecting a game object
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
        
    }
    
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.Variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.Log("Ink Variable was null: " + variableName);
        }
        return variableValue;
    }

    public bool SetVariableState(Story story, string variableName, Ink.Runtime.Object value, bool log=true)
    {
        if (story != null && story.variablesState.GlobalVariableExistsWithName(variableName))
        {
            // if (dialogueVariables.Variables.ContainsKey(variableName))
            // {
            //     dialogueVariables.Variables.Remove(variableName);
            //     dialogueVariables.Variables.Add(variableName, value);
            // }
            if (log) 
            {
                Debug.Log("Set variable: " + variableName + " = " + value);
            }

            story.variablesState[variableName] = value;
            return true;
        }

        return false;
    }
}
