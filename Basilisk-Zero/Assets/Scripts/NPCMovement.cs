using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCMovement : MonoBehaviour
{
     // Speed of the NPC
    [SerializeField] private float speed = 2f;
    
    // Time between movements
    [SerializeField] private float moveDelay = 1f;

    // Internal variables
    private Vector2 movement;
    private float timeSinceLastMove;

    private void Update() {
        if (InkDialogueManager.GetInstance().dialogueIsPlaying || MenuManager.GetInstance().menuIsOpen) {
            return;
        }

        if (timeSinceLastMove >= moveDelay) {
            // Calculate a new movement direction
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            // Reset the time since last move
            timeSinceLastMove = 0f;
        } 
        else {
            // Increment the time since last move
            timeSinceLastMove += Time.deltaTime;
        }
        // Move the NPC based on the movement direction and speed
        transform.position += new Vector3(movement.x, movement.y, 0f) * speed * Time.deltaTime;
    }
        

    public void Move() {
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
    }

    public void Start() 
    {
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        timeSinceLastMove = 0f;
    }

}
