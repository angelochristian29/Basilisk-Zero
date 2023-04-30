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
        if (playerInRange && !InkDialogueManager.GetInstance().dialogueIsPlaying) {
            visualCue.SetActive(true);
            //Detect when the E arrow key is pressed down
            if (Input.GetButtonUp("Fire1")) {
                InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
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
        //Debug.Log($"Started conversation with {name}.");
        isCurrentConversation = true;
    }

    private void EndConversation() {
        if (isCurrentConversation) {
            visualCue.SetActive(false);
            isCurrentConversation = false;
            //Debug.Log($"Started conversation with {name}.");
        }
    }

}
