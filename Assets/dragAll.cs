using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAll : MonoBehaviour
{
    private Transform dragging = null;
    private Vector3 offset;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        }
    }
}

