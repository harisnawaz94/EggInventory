using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPick : MonoBehaviour
{
    public Item Item;
    public Text inventoryFullText; // Reference to the UI text element for displaying the message

    void Pickup()
    {
        if (InventoryManager.Instance.Items.Count < 8)
        {
            InventoryManager.Instance.Add(Item);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Inventory is full. Cannot pick up item.");
            if (inventoryFullText != null)
            {
                inventoryFullText.gameObject.SetActive(true); // Make the text element visible
                inventoryFullText.text = "Inventory is full!"; // Set the text of the UI element to display the message
                StartCoroutine(ClearMessage(2f)); // Clear the message after 2 seconds
            }
        }
    }

    IEnumerator ClearMessage(float delay)
    {
        yield return new WaitForSeconds(delay);
        inventoryFullText.text = ""; // Clear the message after the specified delay
        inventoryFullText.gameObject.SetActive(false); // Hide the text element
    }

    public void OnMouseDown()
    {
        Pickup();
    }
}
