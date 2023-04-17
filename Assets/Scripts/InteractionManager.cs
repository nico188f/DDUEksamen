using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    Item CurrentlySelectedItem;
    bool isInPlacementZone = false;
    public BuildingPreview BuildingPreview;

    // Update is called once per frame
    void Update()
    {
        if (isInPlacementZone)
        {
            if (CurrentlySelectedItem != InventoryManager.Instance.GetSelectedItem(false))
            {
                CurrentlySelectedItem = InventoryManager.Instance.GetSelectedItem(false);
                BuildingPreview.CheckIfItemIsValid(CurrentlySelectedItem);
            }
        }
        BuildingPreview.SetLocation(transform.position);

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "PlacementZone":
                EnterPlacementZone();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "PlacementZone":
                ExitPlacementZone();
                break;
            default:
                break;
        }
    }

    void EnterPlacementZone()
    {
        isInPlacementZone = true;
        CurrentlySelectedItem = InventoryManager.Instance.GetSelectedItem(false);
        BuildingPreview.CheckIfItemIsValid(CurrentlySelectedItem);
    }

    void ExitPlacementZone()
    {
        isInPlacementZone = false;
        BuildingPreview.SpriteRenderer.color = new Color(0, 0, 0, 0);
    }
}
