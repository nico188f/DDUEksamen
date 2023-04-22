using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSceneItemDespawnZone : MonoBehaviour
{
    public ShopItemSpawner ShopItemSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ShopSceneItem"))
        {
            ShopItemSpawner.activeShopItems--;
            Destroy(collision.gameObject);
        }
    }
}
