using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("chooseLevel", (string levelName, string enterName) => {
            //Debug.Log(levelName);
            PlayerController.instance.transitionName = enterName;
            SceneManager.LoadScene(levelName);
        });
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("chooseLevel");
    }

    
}
