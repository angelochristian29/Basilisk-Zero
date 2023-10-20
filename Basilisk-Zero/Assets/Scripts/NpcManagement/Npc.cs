using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Common properties for all NPCs
    [SerializeField] private float speed = 0f;
    [SerializeField] public float waitTime = 3f;
    [SerializeField] public float walkTime = 0f;

    // Common methods for all NPCs
    public void Move()
    {
        // Implementation for moving the NPC
        
    }

    public void Interact()
    {
        // Implementation for interacting with the NPC
    }

    public void StartDialogue()
    {
       

    } 
}
