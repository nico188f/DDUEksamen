using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Color PreviewColor;
    public Color IllegalLocationColor;
    public int illLegalLocations;

    void UpdateSprite(Sprite newSprite)
    {
        SpriteRenderer.sprite = newSprite;
        SpriteRenderer.color = PreviewColor;

    }

    public void CheckIfItemIsValid(Item CurrentlySelectedItem)
    {
        if (CurrentlySelectedItem != null && CurrentlySelectedItem.itemType == ItemType.Placeble)
        {
            UpdateSprite(CurrentlySelectedItem.Building.GetComponent<SpriteRenderer>().sprite);
        }
        else
        {
            SpriteRenderer.color = new Color(0, 0, 0, 0);
        }

    }

    public void SetLocation(Vector3 InteractionLocation)
    {
        transform.position = new Vector3(Mathf.Round(InteractionLocation.x), Mathf.Round(InteractionLocation.y), 1);
    } 
    
    public bool TryToPlaceBuilding(GameObject Building)
    {
        if (illLegalLocations == 0)
        {
            Instantiate(Building, transform.position, Quaternion.identity);
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Building"))
        {
            illLegalLocations++;
            SpriteRenderer.color = IllegalLocationColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Building"))
        {
            illLegalLocations--;
            if(illLegalLocations == 0)
            {
                SpriteRenderer.color = PreviewColor;
            }
        }
    }

}
