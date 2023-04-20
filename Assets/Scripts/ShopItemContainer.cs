using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemContainer : MonoBehaviour
{
    public Item item;
    public GameObject sprite;
    public GameObject button;
    public GameObject priceText;

    public void InitializeShopItem(Item tempItem)
    {
        item = tempItem;
        sprite.GetComponent<Image>().sprite = item.sprite;
    }
}
