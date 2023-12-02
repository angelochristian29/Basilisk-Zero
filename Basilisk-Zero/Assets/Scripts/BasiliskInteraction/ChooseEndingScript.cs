using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseEndingScript : MonoBehaviour
{
    [SerializeField] public GameObject visualCue;
    [SerializeField] public GameObject endingCanvas;
    [SerializeField] private string sceneToLoad;
    [SerializeField] public string storyVariableName;
    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }


// When you activate game object
    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
        endingCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int storyVariableValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState(storyVariableName)).value;
        //int derailmentValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("derailment")).value;

        if (storyVariableValue >= 100) {
            endingCanvas.SetActive(true);

            //Check item list for Level 2 Keycard, then allow player to enter elevator
            if (playerInRange) {
                visualCue.SetActive(true);
                if (Input.GetButtonUp("Fire1")) {
                    MenuManager.GetInstance().FadeImage();
                    StartCoroutine(LoadSceneCoroutine());
                }
            } else {
                visualCue.SetActive(false);
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            playerInRange = false;
        }
    }

    IEnumerator LoadSceneCoroutine() {
        yield return new WaitForSeconds(1f);
        MenuManager.GetInstance().FadeImage();
        yield return new WaitForSeconds(1f);
        MenuManager.GetInstance().HideFadeImage();
        SceneManager.LoadScene(sceneToLoad);
    }
}
