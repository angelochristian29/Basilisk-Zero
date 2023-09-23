using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;

    public static MenuManager instance;

    [SerializeField] GameObject itemSlotContainer;
    [SerializeField] Transform itemSlotContainerParent;
    [SerializeField] GameObject mapContainer;

    public TextMeshProUGUI itemName, itemDescription;

    public bool menuIsOpen { get; private set; }
    
    private Scene currentScene;
    private string sceneName;
    [SerializeField] private Sprite f1Map;
    [SerializeField] private Sprite f2Map;

    public static MenuManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {   
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }

        menuIsOpen = false;
        menu.SetActive(false);
        DontDestroyOnLoad(gameObject);
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
                UpdateInventory();
                UpdateMap();
                menu.SetActive(true);
                menuIsOpen = true;
            }
        }
    }

    public void UpdateInventory()
    {
        // Get rid of duplicates
        foreach (Transform itemSlot in itemSlotContainerParent) 
        {
            Object.Destroy(itemSlot.gameObject);
        }

        // add items from inventory List
        foreach (ItemManager item in Inventory.instance.GetItems()) 
        {
            RectTransform itemSlot = Instantiate(itemSlotContainer, itemSlotContainerParent).GetComponent<RectTransform>();

            Image itemImage = itemSlot.Find("Item Image").GetComponent<Image>();
            itemImage.sprite = item.itemImage;

            TextMeshProUGUI itemAmtText = itemSlot.Find("Item Amount").GetComponent<TextMeshProUGUI>();
            if (item.amt > 1) 
                itemAmtText.text = item.amt.ToString();
            else
                itemAmtText.text = "";

            itemSlot.GetComponent<ItemButtonClick>().SetItemOnButton(item);

        }
    }

    public void UpdateMap() 
    {
        // Get current scene and the name of the scene
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        Image mapImage = mapContainer.GetComponent<Image>();

        // Change png of map in the menu depending on what scene player is in
        switch (sceneName)
        {
            case "FirstFloor":
                mapImage.sprite = f1Map;
                break;
            case "SecondFloor":
                mapImage.sprite = f2Map;
                break;
            default:
                break;
        }

    }

    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("You have quit");
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("StartFadeToBlack");
        //imageToFade.GetComponent<Animator>().SetBool("FadeBool", fade);
    }
}
