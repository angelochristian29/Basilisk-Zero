using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
  
    void Start(){


    }
    void Update(){

    }
    public void StartButton()
    {
        SceneManager.LoadScene("FirstFloor");
    }

    // Update is called once per framee
    public void Settings()
    {
     SceneManager.LoadScene("ControlsMenu");   
     //Controls Menu is different scenne
    }
    public void Back()
    {
        SceneManager.LoadScene("Title");
    }
   
    public void Quit()
    {
        //Application.Quit();
        Debug.Log("Quit");
    }
}
