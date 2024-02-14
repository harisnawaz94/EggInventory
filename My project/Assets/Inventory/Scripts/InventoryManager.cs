using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public void Awake()
    {
        Instance = this;
    }
    
    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }
    public void ListItem()
    {
        // Clear the existing inventory items
        foreach (Transform child in ItemContent)
        {
            Destroy(child.gameObject);
        }

        // Limit to only 8 items
        int itemCount = Mathf.Min(Items.Count, 8);
        for (int i = 0; i < itemCount; i++)
        {
            Item item = Items[i];
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }

}
