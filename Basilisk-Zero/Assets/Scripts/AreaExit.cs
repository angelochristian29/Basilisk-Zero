using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] string sceneToLoad;
    [SerializeField] string transitionAreaName;
    [SerializeField] AreaEnter areaEnter;

    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        areaEnter.transitionAreaName = transitionAreaName;
    }

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange) {
            visualCue.SetActive(true);
            if (Input.GetButtonUp("Fire1")) {
                PlayerController.instance.transitionName = transitionAreaName;
                SceneManager.LoadScene(sceneToLoad);
            }
        } else {
            visualCue.SetActive(false);
        }
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
}