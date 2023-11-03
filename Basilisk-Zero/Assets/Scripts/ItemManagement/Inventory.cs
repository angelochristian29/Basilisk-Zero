using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private List<ItemManager> itemsList;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance in scene.");
        }
        instance = this;
        itemsList = new List<ItemManager>();
       

    }

    public static Inventory GetInstance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<ItemManager> GetItems() 
    {
        return itemsList;
    }

    public void AddItems(ItemManager item)
    {
        if (item.isStackable)
        {
            bool itemAlreadyInInventory = false;
            foreach (ItemManager itemInInventory in itemsList)
            {
                if (itemInInventory.itemName == item.itemName)
                {
                    itemInInventory.amt += item.amt;
                    itemAlreadyInInventory = true;
                }
            }

            if (!itemAlreadyInInventory)
            {
                itemsList.Add(item);
            }
        } else {
            itemsList.Add(item);
        }
    }
    public bool isInInventory(string itemName){
        //This method will check the inventory for a specific item
        //If the item is in the inventory, it will return true
        //If the item is not in the inventory, it will return false
       
        foreach (ItemManager itemInInventory in itemsList)
        {
            if (itemInInventory.itemName == itemName)
            {
                
                    return true;
            }
        }
        return false;
    }
}
