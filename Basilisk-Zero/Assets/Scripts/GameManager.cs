using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameMenuOpened, dialogueIsPlaying;

    //[SerializeField] 
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenuOpened || dialogueIsPlaying)
        {
            
        }

    }

    
}
