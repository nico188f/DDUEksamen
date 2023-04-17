using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Item[] StartItems;
    public InventorySlot[] InventorySlots;
    public GameObject InventoryItemPrefab;

    public int selectedSlot = -1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeSelectedSlot(0);
        foreach (Item item in StartItems)
        {
            AddItem(item);
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) // checks if the scrollwheel is used
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (selectedSlot == 6)
                {
                    ChangeSelectedSlot(0);
                }
                else
                {
                    ChangeSelectedSlot(selectedSlot + 1);
                }
            }
            else
            {
                if (selectedSlot == 0)
                {
                    ChangeSelectedSlot(6);
                }
                else
                {
                    ChangeSelectedSlot(selectedSlot - 1);
                }
            }
        }
        else if (Input.inputString != null)
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

    public Item GetSelectedItem(bool itemGetsUsed)
    {
        InventorySlot Slot = InventorySlots[selectedSlot];
        InventoryItem ItemInSlot = Slot.GetComponentInChildren<InventoryItem>();
        if (ItemInSlot != null)
        {
            Item Item = ItemInSlot.item;
            if (itemGetsUsed)
            {
                ItemInSlot.count--;
                if (ItemInSlot.count <= 0)
                {
                    Destroy(ItemInSlot.gameObject);
                }
                else
                {
                    ItemInSlot.RefreshCount();
                }
            }
            return ItemInSlot.item;
        }

        return null;
    }
}
