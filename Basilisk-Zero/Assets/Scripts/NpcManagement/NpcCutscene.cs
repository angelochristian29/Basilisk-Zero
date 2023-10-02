using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NpcCutscene : MonoBehaviour
{
    // Speed of the NPC
    [SerializeField] public float speed = 0f;
    [SerializeField] private GameObject dawn; // The Nico object
    [SerializeField] private TextAsset inkJSON; // The ink JSON file
    protected Rigidbody2D dawnRb; // The Rigidbody2D component of the Nico object
    // Internal variables
    protected Rigidbody2D playerRb;
    public Rigidbody2D rb; // The Rigidbody2D component
    public bool isMoving; // Flag indicating if the NPC is currently moving
    protected Vector3 walkDirection3D; // The direction to walk towards

    public bool NPCTrigger1; // Flag indicating if the dialogue should be triggered
    public bool NPCTrigger2;
    public bool NPCTrigger3;
    public bool NicoDialogueDone; // Flag indicating if the dialogue is done
    // public PlayerController playerController; // The PlayerController component

    // public NPCMovement npcmovement;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        dawnRb = dawn.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the Nico object
         // playerRb = playerController.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    public virtual void Update()
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
    public virtual void TriggerNPC(bool NPCTrigger, Rigidbody2D moveToObject)
    {
        if (NPCTrigger == true)
        {
            // Trigger ink dialogue here
            // npcmovement.scriptOffTrigger = true;
            ChooseDirection(moveToObject); // Choose the direction to walk towards
            StartInkDialogue(moveToObject, NPCTrigger);
            moveNPCto(); // Move Nico
        }
    }
    
    // Choose the direction to walk towards
    public virtual void ChooseDirection(Rigidbody2D moveToObject)
    {
        walkDirection3D = (moveToObject.transform.position - rb.transform.position).normalized; // Calculate the direction towards the 
        isMoving = true;
    }
    public virtual void StartInkDialogue(Rigidbody2D moveToObject, bool NPCTrigger)
    {
        // check if moveToObject is a Rigidbody2D
        if (moveToObject.GetComponent<Rigidbody2D>() == null)
        {
            return; // Exit the function
        }
        else if (Vector2.Distance(moveToObject.transform.position, rb.transform.position) < 1.0f)
        {
            isMoving = false; // Set the isMoving flag to false
            InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON); // Start the ink dialogue
            NicoDialogueDone = true;
            NPCTrigger = false;
            // npcmovement.scriptOffTrigger = false;
            return; // Exit the function
        }
    }
    // Move Nico in the specified direction
    public virtual void moveNPCto()
    {
        if (isMoving)
        {
            // Move towards the player
            rb.velocity = walkDirection3D * speed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Set the velocity to zero
        }
    }

}