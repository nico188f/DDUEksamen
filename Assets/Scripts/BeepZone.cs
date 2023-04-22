using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepZone : MonoBehaviour
{
    public AudioSource BeepSoundEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShopSceneItem"))
        {
            BeepSoundEffect.Play();
            collision.gameObject.GetComponent<ShopSceneItem>().isBeebed = true;
            CashManager.cash += collision.gameObject.GetComponent<ShopSceneItem>().item.sellPrice;
        }
    }
}
