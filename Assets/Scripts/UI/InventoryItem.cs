using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Experimental.Rendering;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    

    public Item item;

    public Image image;
    public TextMeshProUGUI text;

    public int count = 0;

    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        InitialiseItem(item);
    }
    public void InitialiseItem(Item NewItem)
    {
        item = NewItem;
        image.sprite = NewItem.sprite;
    }
    public void RefreshCount(bool showCount)
    {
        if (showCount)
        {
            text.text = count.ToString();
        }
        else
        {
            text.text = "";
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    } 

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
