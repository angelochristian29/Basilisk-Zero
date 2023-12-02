using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NpcCutscene : MonoBehaviour
{
    // Speed of the NPC
    [SerializeField] public float speed = 1.5f;
     [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON; // The ink JSON file
    // Internal variables
    protected Rigidbody2D playerRb;
    public Rigidbody2D rb; // The Rigidbody2D component
    private bool isMoving; // Flag indicating if the NPC is currently moving
    protected Vector3 walkDirection3D; // The direction to walk towards
    public bool Guard = true;
    public bool NPCTrigger1 = true; // Flag indicating if the dialogue should be triggered
    public bool NicoDialogueDone; // Flag indicating if the dialogue is done
    // public PlayerController playerController; // The PlayerController component
    private bool playerIsInRange;

    private bool isInteracted;

    public bool guardMovemnt;

    // public NPCMovement npcmovement;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        // playerRb = playerController.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        // Check if dialogue is playing or menu is open
        if (InkDialogueManager.GetInstance().dialogueIsPlaying || MenuManager.GetInstance().menuIsOpen || isInteracted==true)
        {
            rb.velocity=Vector2.zero;
            return; // Exit the function
        }
        // if the player is in range then trigger then set the NPCTrigger1 flag to true
        if (Vector2.Distance(PlayerController.instance.playerRB.transform.position, rb.transform.position) < 4.0f)
        {
            
            // Check if Nico object is authorized to move and if the dialogue needs to be triggered
            TriggerNPC(NPCTrigger1, PlayerController.instance.playerRB);
        }
    }

    public void Interact()
    {
    if (Input.GetButtonUp("Fire1"))
    {
        isInteracted = true;
        rb.velocity = Vector2.zero;
    }
    }

    // Trigger the ink dialogue when NPC reaches a set point
    public virtual void TriggerNPC(bool NPCTrigger, Rigidbody2D moveToObject)
    {
        if (NPCTrigger == true)
        {
            ChooseDirection(moveToObject); // Choose the direction to walk towards
            StartInkDialogue(moveToObject, NPCTrigger);
            moveNPCto(); // Move Nico
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        // If the player enters the trigger zone
        if (collider.gameObject.tag == "Player") {
            playerIsInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider) {
        // If the player exits the trigger zone
        if (collider.gameObject.tag == "Player") {
            playerIsInRange = false;
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
        int supportAIValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("supportAI")).value;
        int derailment = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("derailment")).value;
        // check if moveToObject is a Rigidbody2D
        if (moveToObject.GetComponent<Rigidbody2D>() == null)
        {
            return; // Exit the function
        }
        
        else if (playerIsInRange)
        {
            isMoving = false; // Set the isMoving flag to false
            InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON); // Start the ink dialogue
            Debug.Log("Dialogue started");
            Debug.Log("Dialogue started");
            NicoDialogueDone = true;
            NPCTrigger1 = false;
            Debug.Log("Dialogue ended");
            StartCoroutine(teleportPlayer(moveToObject));
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

    public virtual IEnumerator teleportPlayer(Rigidbody2D moveToObject)
    {
        string level = ((Ink.Runtime.StringValue) InkDialogueManager.GetInstance().GetVariableState("sceneToLoad")).value;
        int supportAIValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("supportAI")).value;
        int derailment = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("derailment")).value;
        if (level == "TwentyEighthFloor"){
        yield return new WaitForSeconds(4.0f);
        if (derailment >= 83) {
            moveToObject.transform.position = new Vector2((float) 14.035,(float) 3 );
        }
        else if (derailment < 83 && supportAIValue < 73){
            moveToObject.transform.position = new Vector2((float) 0.057,(float) 10.77 );
        }
        else if (supportAIValue >= 83){
            moveToObject.transform.position = new Vector2((float) 0.057,(float) 10.77 );
        }
        NPCTrigger1 = true;
        }
    }
}