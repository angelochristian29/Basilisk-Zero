using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkDialogueTriggerNeedItem : MonoBehaviour
{
    private bool isCurrentConversation = true;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Item Needed")]
    [SerializeField] private string requiredItemName;
    private bool playerInRange;

    private string sceneToLoad;

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    /*void OnInteract(InputValue intPress) {

    }*/

    private void Update() {
        //int derailment = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("derailment")).value;
        int derailment = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("derailment")).value;
        int supportAIValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("supportAI")).value;
        if (playerInRange && isCurrentConversation && !InkDialogueManager.GetInstance().dialogueIsPlaying && Inventory.GetInstance().isInInventory(requiredItemName) && (derailment > 30 || supportAIValue > 60)) {
            visualCue.SetActive(true);
            //Detect when the E key is pressed down
            if (Input.GetButtonUp("Fire1")) {
                InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                EndConversation();
            }
        } else {
            visualCue.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
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
        sceneToLoad = ((Ink.Runtime.StringValue) InkDialogueManager.GetInstance().GetVariableState("sceneToLoad")).value;
        if (sceneToLoad == "SecondFloor" && isCurrentConversation) {
            visualCue.SetActive(false);
            isCurrentConversation = false;
        }
    }
}
