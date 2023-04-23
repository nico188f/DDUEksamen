using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class ExitInteractZone : MonoBehaviour
{

    public Interacteble interacteble;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interacteble.WebShop.SetActive(false);
        }
    }
}
