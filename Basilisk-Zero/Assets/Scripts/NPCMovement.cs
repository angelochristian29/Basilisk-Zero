using UnityEngine;

public class NPCMovement : MonoBehaviour
{
     // Speed of the NPC
    [SerializeField] private float speed = 2f;

    // Time between movements
    [SerializeField] public float waitTime = 3f;
    [SerializeField] public float walkTime = 1f;

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

    private void Update()
    {
        if (InkDialogueManager.GetInstance().dialogueIsPlaying || MenuManager.GetInstance().menuIsOpen)
        {
            return;
        }

        moveNPC();

    }

    private void moveNPC()
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

    /*public void Move() {
        if (InkDialogueManager.GetInstance().dialogueIsPlaying || MenuManager.GetInstance().menuIsOpen) {
            return;
        }
        // generate a random direction
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        // normalize the vector so that the sum of the components is equal to 1
        Vector2 direction = new Vector2(x, y).normalized;
        // move the object in the direction
        transform.Translate(direction * speed * Time.deltaTime);
    }*/

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0,4);
        isMoving = true;
        walkCounter = walkTime;
    }

}
