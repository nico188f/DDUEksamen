using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] InventorySlots;
    public GameObject InventoryItemPrefab;


    public void AddItem(Item item)
    {
        foreach (InventorySlot inventorySlot in InventorySlots)
        {
            InventoryItem ItemInSlot = inventorySlot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot == null)
            {
                SpawnNewItem(item, inventorySlot);
                return;
            }
        }
    }

    public void SpawnNewItem(Item item, InventorySlot inventorySlot)
    {
        GameObject newItemInInventory = Instantiate(InventoryItemPrefab, inventorySlot.transform);
        InventoryItem inventoryItem = newItemInInventory.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void Remove(Item item) 
    { 
        
    }
}
