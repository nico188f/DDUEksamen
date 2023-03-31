using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAndMoneyPickUp : MonoBehaviour
{
    public InventoryManager inventoryManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DroppedItem"))
        {
            inventoryManager.AddItem(collision.gameObject.GetComponent<DroppedItem>().item);
            Destroy(collision.gameObject);
        }
    }
}
