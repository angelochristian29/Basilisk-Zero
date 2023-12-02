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
        story.BindExternalFunction("chooseLevel", (string levelName) => {
            //PlayerController.GetInstance().transitionName = enterName;
            //SceneManager.LoadScene(levelName);

        });

        /*story.BindExternalFunction("backToStart", (string levelName, string enterName) => {
            PlayerController.GetInstance().transitionName = enterName;
            SceneManager.LoadScene(levelName);
        });*/
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
