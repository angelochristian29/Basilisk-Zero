using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class StationaryInteractable : MonoBehaviour {
    // internal properties exposed to editor
    [SerializeField] private string conversationStartNode;
    // Speed of the NPC

    // Internal variables
    private Vector2 movement;
    private float timeSinceLastMove;

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

    /*void OnInteract(InputValue intPress) {

    }*/

    private void Update() {
        if (playerInRange && interactable) {
            visualCue.SetActive(true);
            //Detect when the E arrow key is pressed down
            if (Input.GetButtonUp("Fire1")) {
                //Debug.Log("E key was pressed.");
                if (!dialogueRunner.IsDialogueRunning) {
                    StartConversation();
                }
            }
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
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        timeSinceLastMove = 0f;
        
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