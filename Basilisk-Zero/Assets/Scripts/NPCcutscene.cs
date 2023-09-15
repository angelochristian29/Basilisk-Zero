using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPCcutscene : MonoBehaviour
{
    // Speed of the NPC
    [SerializeField] private float speed = 0f;

    // Time between movements
    [SerializeField] public float waitTime = 3f; // The time to wait before moving again
    [SerializeField] public float walkTime = 0f; // The time to walk in a direction

    [SerializeField] private TextAsset inkJSON; // The Ink JSON file for dialogue

    [SerializeField] private GameObject dawn; // The Nico object
    private Rigidbody2D dawnRb; // The Rigidbody2D component of the Nico object
    // Internal variables

    private Rigidbody2D playerRb;
    private Vector2 movement; // The movement vector
    private float timeSinceLastMove; // The time since the last movement
    private Rigidbody2D rb; // The Rigidbody2D component
    public bool isMoving; // Flag indicating if the NPC is currently moving
    private float walkCounter; // The counter for walking time
    private float waitCounter; // The counter for waiting time
    // Directions
    private Vector3 walkDirection; // The direction to walk towards

    public bool NPCTrigger1; // Flag indicating if the dialogue should be triggered
    public bool NPCTrigger2;
    public bool NPCTrigger3;
    public bool NicoDialogueDone; // Flag indicating if the dialogue is done
    // public PlayerController playerController; // The PlayerController component

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        dawnRb = dawn.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the Nico object
         // playerRb = playerController.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if dialogue is playing or menu is open
        if (InkDialogueManager.GetInstance().dialogueIsPlaying || MenuManager.GetInstance().menuIsOpen)
        {
            return; // Exit the function
        }
        if (NicoDialogueDone == true)
        {
            TriggerNPC(NPCTrigger1, dawnRb);
        }
        else
        {
            // Check if Nico object is authorized to move and if the dialogue needs to be triggered
            TriggerNPC(NPCTrigger2, PlayerController.instance.playerRB);
        }
    }

    // Trigger the ink dialogue when NPC reaches a set point
    private void TriggerNPC(bool NPCTrigger, Rigidbody2D moveToObject)
    {
        if (NPCTrigger == true)
        {
            // Trigger ink dialogue here
            ChooseDirection(moveToObject); // Choose the direction to walk towards
            StartInkDialogue(moveToObject, NPCTrigger);
            moveNPCto(); // Move Nico
        }
    }
    
    // Choose the direction to walk towards
    public void ChooseDirection(Rigidbody2D moveToObject)
    {
        walkDirection = (moveToObject.transform.position - rb.transform.position).normalized; // Calculate the direction towards the 
        isMoving = true;
        // StartInkDialogue();
        // Check if Nico is close to the player rigid body and if so stop moving
        // Set the isMoving flag to true
    }
    public void StartInkDialogue(Rigidbody2D moveToObject, bool NPCTrigger)
    {
        if (Vector2.Distance(moveToObject.transform.position, rb.transform.position) < 1.0f)
        {
            isMoving = false; // Set the isMoving flag to false
            InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON); // Start the ink dialogue
            NicoDialogueDone = true;
            NPCTrigger = false;
            return; // Exit the function
        }
    }
    // Move Nico in the specified direction
    private void moveNPCto()
    {
        if (isMoving)
        {
            walkCounter -= Time.deltaTime; // Decrease the walk counter
            // Move towards the player
            rb.velocity = walkDirection * speed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Set the velocity to zero
        }
    }

}