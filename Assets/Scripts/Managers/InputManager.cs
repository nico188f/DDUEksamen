using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject inventory;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            inventory.SetActive(!inventory.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inventory.activeSelf)
        {
            inventory.SetActive(false);
        }
    }
}
