using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacteble : MonoBehaviour
{
    public GameObject WebShop;
    public void initialize(GameObject tempWebShop)
    {
        WebShop = tempWebShop;
    }
    public void interact()
    {
        Debug.Log("ikodfnsopinfdspoinfds");
        WebShop.SetActive(!WebShop.activeSelf);
    }
}
