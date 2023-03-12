using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movFilter;

    Vector2 movInput;
    SpriteRenderer spriteRend;
    Rigidbody2D playerRB;
    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

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
    }

    void OnMove(InputValue movVal)
    {
        movInput = movVal.Get<Vector2>();
    }
}
