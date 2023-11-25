using UnityEngine;

public class NPCMovement : MonoBehaviour
{
     // Speed of the NPC
    [SerializeField] private float speed = 0f;

    // Time between movements
    [SerializeField] public float waitTime = 3f;
    [SerializeField] public float walkTime = 0f;

    // Internal variables
    private Vector2 movement;
    private float timeSinceLastMove;

    private Rigidbody2D rb;
    public bool isMoving;
    private float walkCounter;
    private float waitCounter;

    // Directions
    private int walkDirection;
    
    public void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter =  walkTime;

        ChooseDirection();
    }

    public void Update()
    {
        // dialogueIsPlaying isn't working here
        if (InkDialogueManager.GetInstance().dialogueIsPlaying || MenuManager.GetInstance().menuIsOpen)
        {
            return;
        }
        
        moveNPC();

    }

    public void moveNPC()
    {
        if (isMoving)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    rb.velocity = new Vector2(0, speed);
                    break;
                case 1:
                    rb.velocity = new Vector2(speed, 0);
                    break;
                case 2:
                    rb.velocity = new Vector2(0, -speed);
                    break;
                case 3:
                    rb.velocity = new Vector2(-speed, 0);
                    break;
                default:
                    break;
            }

            if (walkCounter < 0)
            {
                isMoving = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }


    public void ChooseDirection()
    {
        walkDirection = Random.Range(0,4);
        isMoving = true;
        walkCounter = walkTime;
    }

}
