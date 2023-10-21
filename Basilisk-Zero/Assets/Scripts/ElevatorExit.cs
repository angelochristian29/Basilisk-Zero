using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorExit : MonoBehaviour
{
    [SerializeField] public GameObject visualCue;
    [SerializeField] public string sceneToLoad = "";
    [SerializeField] string transitionAreaName;

    private static ElevatorExit instance;
    private bool playerInRange;
    private bool choseLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        //gameObject.SetActive(false);
    }


    // When you activate game object
    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        choseLevel = ((Ink.Runtime.BoolValue) InkDialogueManager.GetInstance().GetVariableState("choseLevel")).value;

        if (choseLevel)
        {
            visualCue.SetActive(true);
            sceneToLoad = ((Ink.Runtime.StringValue)InkDialogueManager.GetInstance().GetVariableState("sceneToLoad")).value;
        }

        //Check item list for Level 2 Keycard, then allow player to enter elevator
        if (playerInRange)
        {
            //visualCue.SetActive(true);
            if (Input.GetButtonUp("Fire1"))
            {
                PlayerController.GetInstance().transitionName = transitionAreaName;
                MenuManager.GetInstance().FadeImage();
                StartCoroutine(LoadSceneCoroutine());
            }
        }
        else
        {
            //visualCue.SetActive(false);
        }

    }

    public static ElevatorExit GetInstance()
    {
        return instance;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);

        MenuManager.GetInstance().FadeImage();
        SceneManager.LoadScene(sceneToLoad);
    }

    public void BringToNextLevel(string levelName)
    {
        instance.sceneToLoad = levelName;
        gameObject.SetActive(true);
    }

}
