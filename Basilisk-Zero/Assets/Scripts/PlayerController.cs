using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float movSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movFilter;
    public string transitionName;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    [SerializeField] Tilemap tilemap;

    Vector2 movInput;
    SpriteRenderer spriteRend;
    Rigidbody2D playerRB;
    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);

        bottomLeftEdge = tilemap.localBounds.min + new Vector3(1.5f, 1.5f, 0);
        topRightEdge = tilemap.localBounds.max + new Vector3(-1.5f, -1.5f, 0);
    }

    
    private void Update() {
        float horizMov = Input.GetAxisRaw("Horizontal");
        float vertMov = Input.GetAxisRaw("Vertical");
        
        //playerRB.velocity = new Vector2(horizMov, vertMov) * movSpeed;

        if (horizMov == 1 || horizMov == -1 || vertMov == 1 || vertMov == -1) {
            
            animator.SetBool("isMoving", true);
            // Flip x direction depending on input
            if (movInput.x < 0)
            {
                spriteRend.flipX = true;
            } else if (movInput.x > 0) {
                spriteRend.flipX = false;
            }

        } else {
            animator.SetBool("isMoving", false);
        }

        
        playerRB.MovePosition(playerRB.position + movSpeed * Time.fixedDeltaTime * movInput);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
        );
    }

    /*
    // For handling player input
    private void FixedUpdate()
    {
        if (movInput != Vector2.zero)
        {
            bool tryMov = CastMove(movInput);

            // try moving only on x axis
            if (!tryMov)
            {
                tryMov = CastMove(new Vector2(movInput.x, 0));
            }

            // try moving only on y axis
            if (!tryMov)
            {
                tryMov = CastMove(new Vector2(0, movInput.y));
            }

            animator.SetBool("isMoving", tryMov);
        } else
        {
            animator.SetBool("isMoving", false);
        }

        // Flip x direction depending on input
        if (movInput.x < 0)
        {
            spriteRend.flipX = true;
        } else if (movInput.x > 0) {
            spriteRend.flipX = false;
        }
    }

    private bool CastMove(Vector2 dir)
    {
        if (dir == Vector2.zero)
        {
            return false;
        }
            // Checks to see if player collides with anything
        int colCount = playerRB.Cast(
            dir,
            movFilter, 
            castCollisions, 
            movSpeed * Time.fixedDeltaTime + collisionOffset);

        if (colCount == 0)
        {
            playerRB.MovePosition(playerRB.position + movSpeed * Time.fixedDeltaTime * dir);
            return true;
        } else
        {
            return false;
        }
    }*/

    void OnMove(InputValue movVal)
    {
        movInput = movVal.Get<Vector2>();
    }
}
