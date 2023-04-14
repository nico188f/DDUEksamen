using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] InventorySlots;
    public GameObject InventoryItemPrefab;

    public int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }

    void ChangeSelectedSlot(int newSlotIndex)
    {
        if (selectedSlot >= 0)
        {
            InventorySlots[selectedSlot].Deselect();
        }
        
        InventorySlots[newSlotIndex].Select();
        selectedSlot = newSlotIndex;
    }

    public bool AddItem(Item item)
    {
        foreach (InventorySlot inventorySlot in InventorySlots)
        {
            InventoryItem ItemInSlot = inventorySlot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot != null &&
                ItemInSlot.item == item &&
                item.stackAmount > ItemInSlot.count)
            {
                ItemInSlot.count++;
                ItemInSlot.RefreshCount();
                return true;
            }
        }

        foreach (InventorySlot inventorySlot in InventorySlots)
        {
            InventoryItem ItemInSlot = inventorySlot.GetComponentInChildren<InventoryItem>();
            if (ItemInSlot == null)
            {
                SpawnNewItem(item, inventorySlot);
                return true;
            }
        }

        return false;
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
