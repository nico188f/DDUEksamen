using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemContainer : MonoBehaviour
{
    public Item item;
    public GameObject sprite;
    public GameObject button;
    public GameObject priceText;
    public GameObject stockText;
    public int stockIndex;

    public void InitializeShopItem(Item tempItem)
    {
        item = tempItem;
        sprite.GetComponent<Image>().sprite = item.sprite;
        priceText.GetComponent<TextMeshProUGUI>().text = $"{item.price.ToString()}$";
        stockText.GetComponent<TextMeshProUGUI>().text = "Stock: " + StockManager.Stock[stockIndex].amount.ToString();

    }

    public void ClickBuyButton()
    {
        StockManager.Stock[stockIndex].amount++;
        stockText.GetComponent<TextMeshProUGUI>().text = "Stock: " + StockManager.Stock[stockIndex].amount.ToString();
    }
}
