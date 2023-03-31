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
            bool result = inventoryManager.AddItem(collision.gameObject.GetComponent<DroppedItem>().item);
            if (result)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                collision.gameObject.layer = LayerMask.NameToLayer("Default");
            }
            
        }
    }
}
