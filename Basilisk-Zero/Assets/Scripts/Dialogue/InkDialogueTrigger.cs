using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InkDialogueTrigger : MonoBehaviour
{
    private bool isCurrentConversation = false;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    /*void OnInteract(InputValue intPress) {

    }*/

    private void Update() {
        int supportAIValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("supportAI")).value;
        int derailAIValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("derailment")).value;
        if (playerInRange && !InkDialogueManager.GetInstance().dialogueIsPlaying) {
            visualCue.SetActive(true);
            //Detect when the E key is pressed down
            // print supportAIValue to console for testing purposes
            Debug.Log("support = "+supportAIValue.ToString());
            Debug.Log("derailment = "+derailAIValue.ToString());
            if (Input.GetButtonUp("Fire1")) {
                InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                Debug.Log("support = "+supportAIValue.ToString());
                Debug.Log("derailment = "+derailAIValue.ToString());
            }
        } else {
            visualCue.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        // If the player enters the trigger zone
        if (collider.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        // If the player exits the trigger zone
        if (collider.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }

    public void Start() 
    {
        
    }

    private void StartConversation() {
        isCurrentConversation = true;
    }

    private void EndConversation() {
        if (isCurrentConversation) {
            visualCue.SetActive(false);
            isCurrentConversation = false;
        }
    }

}
