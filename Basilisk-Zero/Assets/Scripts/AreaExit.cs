using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AreaExit : MonoBehaviour
{
    [SerializeField] public GameObject visualCue;
    [SerializeField] private string sceneToLoad;
    [SerializeField] string transitionAreaName;
    [SerializeField] AreaEnter areaEnter;

    private static AreaExit instance;
    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
        areaEnter.transitionAreaName = transitionAreaName;
    }


// When you activate game object
    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Check item list for Level 2 Keycard, then allow player to enter elevator
        if (playerInRange) {
            visualCue.SetActive(true);
            if (Input.GetButtonUp("Fire1") && Inventory.instance.isInInventory("Level 2 Keycard")) {
                PlayerController.GetInstance().transitionName = transitionAreaName;
                MenuManager.GetInstance().FadeImage();
                StartCoroutine(LoadSceneCoroutine());
            }
        } else {
            visualCue.SetActive(false);
        }

    }

    public static AreaExit GetInstance() {
        return instance;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            playerInRange = false;
        }
    }

    IEnumerator LoadSceneCoroutine() {
        yield return new WaitForSeconds(1f);
        MenuManager.GetInstance().FadeImage();
        SceneManager.LoadScene(sceneToLoad);
    }
}
