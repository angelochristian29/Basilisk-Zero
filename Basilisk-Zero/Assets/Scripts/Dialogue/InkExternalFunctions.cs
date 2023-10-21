using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class InkExternalFunctions
{
    [SerializeField] private GameObject exit;


    //public AreaExit elevator;
    public void Bind(Story story)
    {
        /* 
            Change variable on player to the location they should spawn at
            Then fade canvas to black and load next scene
        */
        story.BindExternalFunction("chooseLevel", (string levelName, string enterName) => {
            //PlayerController.GetInstance().transitionName = enterName;
            //ElevatorExit.GetInstance().BringToNextLevel(levelName);
            //SceneManager.LoadScene(levelName, LoadSceneMode.Single);
            //elevator = GameObject.Find("Elevator").GetComponent<AreaExit>();
            //AreaExit.GetInstance().sceneToLoad = levelName;
            //AreaExit.GetInstance().visualCue.SetActive(true);
            Debug.Log("External Function activated");

        });
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("chooseLevel");
    }

    IEnumerator LoadSceneCoroutine(string levelName) {
        yield return new WaitForSeconds(1f);
        //MenuManager.GetInstance().FadeImage();
        SceneManager.LoadScene(levelName);
    }
}
