using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSpawner : MonoBehaviour
{
    public GameObject ShopItemPrefab;

    public List<Item> ShopItemsToSpawn;

    public float secoundsBetweenShopItemSpawn;
    float secoundsSinceLastShopItemSpawn = 0f;

    public int activeShopItems;

    private void Update()
    {
        
        secoundsSinceLastShopItemSpawn += Time.deltaTime;
        if (ShopItemsToSpawn.Count > 0 && secoundsBetweenShopItemSpawn <= secoundsSinceLastShopItemSpawn)
        {

            secoundsBetweenShopItemSpawn -= secoundsSinceLastShopItemSpawn;

            GameObject shopItem = Instantiate(ShopItemPrefab, transform.position, Quaternion.identity);
            shopItem.GetComponent<ShopSceneItem>().InitializeShopSceneItem(ShopItemsToSpawn[0]);


            ShopItemsToSpawn.RemoveAt(0);

            activeShopItems++;
        }
    }

    public void SpawnShopItem(List<Item> ShopItems)
    {
        foreach (Item item in ShopItems)
        {
            ShopItemsToSpawn.Add(item);
        }
    }
}
