using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnInteractable : MonoBehaviour {
    // internal properties exposed to editor
    [SerializeField] private string conversationStartNode;

    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;
    private bool interactable = true;
    private bool isCurrentConversation = false;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private bool playerInRange;

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() {
        if (playerInRange) {
            if(interactable) {
                visualCue.SetActive(true);
            }
            //Detect when the E arrow key is pressed down
            if (Input.GetKeyDown(KeyCode.E)) {
                //Debug.Log("E key was pressed.");
                if (interactable && !dialogueRunner.IsDialogueRunning) {
                    StartConversation();
                }
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

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
        
    }

    private void StartConversation() {
        //Debug.Log($"Started conversation with {name}.");
        isCurrentConversation = true;
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    private void EndConversation() {
        if (isCurrentConversation) {
            visualCue.SetActive(false);
            isCurrentConversation = false;
            //Debug.Log($"Started conversation with {name}.");
        }
    }

    [YarnCommand("disable")]
    public void DisableConversation() {
        interactable = false;
    }
}