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
    public GameObject computerScreen;
    // Start is called before the first frame update
    public bool gameIsPlaying { get; set; }
    public bool gameIsDone{get;set;}
    void Start()
    {
        gameIsPlaying = false; 
        computerScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (playerInRange && gameIsPlaying) {
            visualCue.SetActive(true);
            //Detect when the E key is pressed down
            if (Input.GetButtonUp("Fire1")) {
                computerScreen.SetActive(true);     //active
            }
            
        } else {
            visualCue.SetActive(false);
        }
         if(gameIsDone==true){
            // visualCue.SetActive(false);
            // Destroy(computerScreen);
            gameObject.SetActive(false);
           
        }
        
    }
     public static OpenTypingGame GetInstance()
    {
        return instance;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            gameIsPlaying=true;
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