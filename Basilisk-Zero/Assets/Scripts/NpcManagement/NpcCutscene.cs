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
    public bool isMoving; // Flag indicating if the NPC is currently moving
    protected Vector3 walkDirection3D; // The direction to walk towards

    public bool NPCTrigger1 = true; // Flag indicating if the dialogue should be triggered
    public bool NicoDialogueDone; // Flag indicating if the dialogue is done
    // public PlayerController playerController; // The PlayerController component

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
        if (InkDialogueManager.GetInstance().dialogueIsPlaying || MenuManager.GetInstance().menuIsOpen)
        {
            return; // Exit the function
        }
        // if the player is in range then trigger then set the NPCTrigger1 flag to true
        if (Vector2.Distance(PlayerController.instance.playerRB.transform.position, rb.transform.position) < 4.0f && NPCTrigger1 == true)
        {
            // Check if Nico object is authorized to move and if the dialogue needs to be triggered
            TriggerNPC(NPCTrigger1, PlayerController.instance.playerRB);
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
        
        else if (Vector2.Distance(moveToObject.transform.position, rb.transform.position) < 4.0f)
        {
            isMoving = false; // Set the isMoving flag to false
            NPCTrigger1 = true;
            InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON); // Start the ink dialogue
            Debug.Log("Dialogue started");
            Debug.Log("Dialogue started");
            NicoDialogueDone = true;
            NPCTrigger1 = false;
            Debug.Log("Dialogue ended");
            // move players position slightly away from the NPC
            /*
            Story story = new ;
            // move players position slightly away from the NPC
            if (derailment >= 70){
                int decrementAmount = 10;
                // Increment the value by the desired amount
                int newValue = derailment - decrementAmount;
                string variableName = "myVariable";
                // Create a new Ink.Runtime.Object with the updated value
                Ink.Runtime.Object updatedValue = new Ink.Runtime.IntValue(newValue);
                InkDialogueManager.GetInstance().SetVariableState(story, variableName, updatedValue, true);
                
            }
            */
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
        if (level == "TwentyEighthFloor"){
        yield return new WaitForSeconds(4.0f);
        moveToObject.transform.position = new Vector2((float) 0.057,(float) 10.77 );
        }


    }


}