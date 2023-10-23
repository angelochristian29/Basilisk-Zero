using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GuardMovement : NpcCutscene
{
    [SerializeField] public float waitTime = 3f;
    [SerializeField] public float walkTime = 0f;
    // Internal variables
    private Vector2 movement;
    private float timeSinceLastMove;
    private float walkCounter;
    private float waitCounter;

    private int walkDirection;

    // private Rigidbody2D rb;
    // public bool isMoving;

    // Directions
    // public int walkDirection;

    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter =  walkTime;

        ChooseDirection();
    }

    public override void Update()
    {
        if (NPCTrigger1)
        {
            base.Start();
            base.Update(); 
        }
        else
        {
            if (InkDialogueManager.GetInstance().dialogueIsPlaying || MenuManager.GetInstance().menuIsOpen)
            {
                return;
            }
        moveNPC();
        }
        
        // if player is within a certain range then apply base.Update()
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


    private void ChooseDirection()
    {
        walkDirection = Random.Range(0,4);
        isMoving = true;
        walkCounter = walkTime;
    }
}