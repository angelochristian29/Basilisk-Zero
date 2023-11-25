using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;
    
    [SerializeField] GameObject itemsParent;
    private ItemManager[] itemsInScene;  

    // Start is called before the first frame update
    void Start()
    {
        SetBounds();
        
    }

    // Update is called once per frame
    void Update()
    {
        //HideObtainedItems();
    }

    public void HideObtainedItems()
    {
        itemsInScene = itemsParent.GetComponentsInChildren<ItemManager>();

        foreach (ItemManager itemInInventory in Inventory.GetInstance().GetItems())
        {
            for (int i = 0; i < itemsInScene.Length; i++)
            {
                if (itemInInventory.name == itemsInScene[i].name)
                {
                    itemsInScene[i].destroyItem();
                }
            }
        }
    }

    private void SetBounds()
    {
        bottomLeftEdge = tilemap.localBounds.min + new Vector3(0f, 1f, 0f);
        topRightEdge = tilemap.localBounds.max + new Vector3(-0f, -1f, 0f);
        PlayerController.GetInstance().SetLimit(bottomLeftEdge, topRightEdge);
    }
}
