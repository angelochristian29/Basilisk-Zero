using UnityEngine;

public class NicoCutscene : MonoBehaviour
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

    public bool NicoDialogueTrigger; // Flag indicating if the dialogue should be triggered
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
            TriggerDialogue(NicoDialogueTrigger, dawnRb);
            // return; // Exit the function
        }
        else
        {
            // Check if Nico object is authorized to move and if the dialogue needs to be triggered
            TriggerDialogue(NicoDialogueTrigger, PlayerController.instance.playerRB);
    
        }
    }

    private void afterCutscene()
    {
        NicoDialogueDone = true;
        NicoDialogueTrigger = false;
        return;
    }

    // Move Nico in the specified direction
    private void moveNico()
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

    // Choose the direction to walk towards
    public void ChooseDirection(Rigidbody2D moveToObject)
    {
        walkDirection = (moveToObject.transform.position - rb.transform.position).normalized; // Calculate the direction towards the player
        // Check if Nico is close to the player rigid body and if so stop moving
        if (Vector2.Distance(PlayerController.instance.transform.position, rb.transform.position) < 1.0f)
        {
            isMoving = false; // Set the isMoving flag to false
            InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON); // Start the ink dialogue
            // InkDialogueManager.GetInstance().canContinueLine == false
            // StartCoroutine(InkDialogueManager.GetInstance().ExitDialogueMode());
            NicoDialogueTrigger = false;
            return; // Exit the function
        }
        isMoving = true; // Set the isMoving flag to true
        walkCounter = walkTime; // Set the walk counter
    }

    // Trigger the ink dialogue when NPC reaches a set point
    private void TriggerDialogue(bool NicoDialogueTrigger, Rigidbody2D moveToObject)
    {
        if (NicoDialogueTrigger == true)
        {
            // Trigger ink dialogue here
            ChooseDirection(moveToObject); // Choose the direction to walk towards
            moveNico(); // Move Nico
        }
    }
}