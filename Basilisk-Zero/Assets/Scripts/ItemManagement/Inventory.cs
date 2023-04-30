using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private List<ItemManager> itemsList;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance in scene.");
        }
        instance = this;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        itemsList = new List<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItems(ItemManager item)
    {
        print(item.itemName + "has been added to inventory");
        itemsList.Add(item);
        print(itemsList.Count);
    }
}
