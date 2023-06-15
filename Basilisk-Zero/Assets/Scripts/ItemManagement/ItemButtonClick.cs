using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonClick : MonoBehaviour
{
    private ItemManager itemOnButton;

    public void SetItemOnButton(ItemManager item)
    {
        itemOnButton = item;
    }

    public void Press()
    {
        MenuManager.instance.itemName.text = itemOnButton.itemName;
        MenuManager.instance.itemDescription.text = itemOnButton.itemDescription;
    }
}
