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

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    /*void OnInteract(InputValue intPress) {

    }*/

    private void Update() {
        if (playerInRange && isCurrentConversation && !InkDialogueManager.GetInstance().dialogueIsPlaying && Inventory.GetInstance().isInInventory(requiredItemName)) {
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
        if (isCurrentConversation) {
            visualCue.SetActive(false);
            isCurrentConversation = false;
        }
    }
}
