using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;

    public static MenuManager instance;

    public bool menuIsOpen { get; private set; }

    public static MenuManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuIsOpen = false;
        instance = this;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel")) {
            if (menu.activeInHierarchy) 
            {
                menu.SetActive(false);
                menuIsOpen = false;
            } else {
                menu.SetActive(true);
                menuIsOpen = true;
            }
        }
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fading");
    }
}
