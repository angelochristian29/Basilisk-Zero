using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTypingGame : MonoBehaviour
{
    public static OpenTypingGame instance; 
    private bool playerInRange;
   [Header("Visual Cue")]
    [SerializeField] 
    private GameObject visualCue;
     [SerializeField] 
    private GameObject computerScreen;
    // Start is called before the first frame update
    public bool gameIsPlaying { get; set; }
    void Start()
    {
        gameIsPlaying = true; 
        computerScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && gameIsPlaying) {
            visualCue.SetActive(true);
            //Detect when the E key is pressed down
            if (Input.GetButtonUp("Fire1")) {
                computerScreen.SetActive(true);
            }
        } else {
            visualCue.SetActive(false);
        }
        
    
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

}