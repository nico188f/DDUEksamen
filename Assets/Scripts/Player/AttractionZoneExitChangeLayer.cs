using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionZoneExitChangeLayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DroppedItem"))
        {
            collision.gameObject.layer = LayerMask.NameToLayer("DroppedItem");

        }
    }
}
