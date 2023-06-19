using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    // Flag to check if dialogue is playing or not (to prevent player from moving) 
    public bool dialogueIsPlaying { get; private set; }
    private static InkDialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";

    private InkDialogueVariables dialogueVariables;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance in scene.");
        }
        instance = this;

        dialogueVariables = new InkDialogueVariables(loadGlobalsJSON);
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
        
        if (Input.GetButtonUp("Fire1") | Input.GetButtonUp("Submit"))
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

        // reset dialogue tags
        displayNameText.text = "???";
        portraitAnimator.Play("default");
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        // Next line the dialogue
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags); // code for handling tags
        } else {
            StartCoroutine(ExitDialogueMode());
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
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
    
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.Log("Ink Variable was null: " + variableName);
        }
        return variableValue;
    }
}
