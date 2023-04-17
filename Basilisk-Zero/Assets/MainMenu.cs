using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string FirstFloor;
    // Start is called before the first frame update
    public GameObject SettingsMenu;
    void Start(){


    }
    void Update(){

    }
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per framee
    public void Settings()
    {
     SceneManager.LoadScene("ControlsMenu");   
    }
    public void Back()
    {
        SceneManager.LoadScene("Title");
    }
    public void OpenOptions(){
        SettingsMenu.SetActive(true);
    }
    public void CloseOptions(){
        SettingsMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
