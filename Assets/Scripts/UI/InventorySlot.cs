using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;

    public Color SelectedColor, DeselectedColor;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = SelectedColor;
    }

    public void Deselect()
    {
        image.color = DeselectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponents<InventoryItem>()[0];
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
