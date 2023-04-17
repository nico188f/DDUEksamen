using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Color PreviewColor;
    public Color Color;

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
    

}
