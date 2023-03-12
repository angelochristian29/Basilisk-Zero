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
    Rigidbody2D playerRB;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // For handling player input
    private void FixedUpdate()
    {
        if (movInput != Vector2.zero)
        {
            bool tryMov = canMove(movInput);

            // try moving only on x axis
            if (!tryMov)
            {
                tryMov = canMove(new Vector2(movInput.x, 0));

                // try moving only on y axis
                if (!tryMov)
                {
                    canMove(new Vector2(0, movInput.y));
                }
            }

        }

    }

    private bool canMove(Vector2 dir)
    {
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
