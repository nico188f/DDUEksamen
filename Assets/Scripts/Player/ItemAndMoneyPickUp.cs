using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAndMoneyPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DroppedItem"))
        {
            InventoryManager.Instance.Add(collision.GetComponent<DroppedItem>().item);
            Destroy(collision.gameObject);
        }
    }
}
