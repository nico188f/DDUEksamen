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
    }
}
