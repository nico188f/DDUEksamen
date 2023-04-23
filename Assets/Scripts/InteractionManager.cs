using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    Item CurrentlySelectedItem;
    bool isInPlacementZone = false;
    public BuildingPreview BuildingPreview;
    bool collideLady = false;
    GameObject lady;
    bool collideComputer = false;
    GameObject computer;
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


        //Building placement
        if (isInPlacementZone && Input.GetKeyDown(KeyCode.E) && CurrentlySelectedItem != null && CurrentlySelectedItem.itemType == ItemType.Placeble)
        {
            if(BuildingPreview.TryToPlaceBuilding(CurrentlySelectedItem.Building))
            {
                InventoryManager.Instance.GetSelectedItem(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && collideLady)
        {
            lady.GetComponent<CharecterDialog>().Interact();
        }
        if (Input.GetKeyDown(KeyCode.E) && collideComputer)
        {
            computer.GetComponent<Interacteble>().interact();
        }

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "PlacementZone":
                EnterPlacementZone();
                break;
            case "Charecter":
                collideLady = true;
                lady = collision.gameObject;
                break;
            case "WebShop":
                collideComputer = true;
                computer= collision.gameObject;
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
            case "Charecter":
                collideLady = false;
                break;
            case "WebShop":
                collideComputer = false;
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
