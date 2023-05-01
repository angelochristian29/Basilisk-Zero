using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;

    public static MenuManager instance;

    [SerializeField] GameObject itemSlotContainer;
    [SerializeField] Transform itemSlotContainerParent;

    public TextMeshProUGUI itemName, itemDescription;

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
                UpdateInventory();
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
                itemAmtText.text = null;
            
            itemSlot.GetComponent<ItemButtonClick>().SetItemOnButton(item);
            
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You have quit");
    }

    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fading");
    }
}
