using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAll : MonoBehaviour
{
    //lavet af: Marcus
    public float yLimit = 2;
    private Transform dragging = null;
    private Vector3 offset;
    [SerializeField] private LayerMask movableLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Cast our own ray.
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                                                 float.PositiveInfinity, movableLayers);
            if (hit)
            {
                // If we hit, record the transform of the object we hit.
                dragging = hit.transform;
                // And record the offset.
                offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Stop dragging.
            dragging = null;
        }

        if (dragging != null)
        {
            Vector3 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePostion.y < yLimit)
            {
                mousePostion.y = yLimit;
            }
            // Move object, taking into account original offset.
            dragging.position = mousePostion + offset;
        }
    }

} 

