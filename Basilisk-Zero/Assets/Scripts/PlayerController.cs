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
            // Checks to see if player collides with anything
            int colCount = playerRB.Cast(
                movInput,
                movFilter, 
                castCollisions, 
                movSpeed + Time.fixedDeltaTime + collisionOffset);

            if (colCount == 0)
            {
                playerRB.MovePosition(playerRB.position + movInput * movSpeed * Time.fixedDeltaTime);
            }
            
        }

    }

    void OnMove(InputValue movVal)
    {
        movInput = movVal.Get<Vector2>();
    }
}
