using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSceneItem : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Item item;

    public bool isBeebed = false;
    public void InitializeShopSceneItem(Item _item)
    {
        item =_item;
        spriteRenderer.sprite = _item.sprite;
    }
}
