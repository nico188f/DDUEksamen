using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class InteractionPointDirectionChanger : MonoBehaviour
{
    Transform interactionPointTransform;

    public float interactionOffset;
    
    void Start()
    {
        interactionPointTransform = GetComponent<Transform>();
    }

    void Update()
    {
        //Sets direction player can interact based on 

        if (Input.GetAxisRaw("Horizontal") > 0)
            interactionPointTransform.localPosition = new Vector2(interactionOffset, 0);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            interactionPointTransform.localPosition = new Vector2(-interactionOffset, 0);
        else if (Input.GetAxisRaw("Vertical") > 0)
            interactionPointTransform.localPosition = new Vector2(0, interactionOffset);
        else if (Input.GetAxisRaw("Vertical") < 0)
            interactionPointTransform.localPosition = new Vector2(0, -interactionOffset);


    }
}
