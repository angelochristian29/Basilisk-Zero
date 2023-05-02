using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool playerInRange;
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    public enum ItemType {Item, Key}
    public ItemType itemType;

    public string itemName, itemDescription;
    public Sprite itemImage;
    public int clearanceLvl;

    public bool isStackable;
    public int amt = 0;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetButtonUp("Fire1")) {
                Inventory.instance.AddItems(this);
                destroyItem();
            }
        } else {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }

    public void destroyItem()
    {
        Object.Destroy(gameObject);
    }
}
