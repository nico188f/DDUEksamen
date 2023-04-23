using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    public AudioSource AudioSource;

    public SpriteRenderer SpriteRenderer;
    public Color PreviewColor;
    public Color IllegalLocationColor;
    public int illLegalLocations;


    public GameObject webshop;
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
            SpriteRenderer.sprite = null;
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

            GameObject temp = Instantiate(Building, transform.position, Quaternion.identity);

            temp.GetComponent<Interacteble>().initialize(webshop);
            AudioSource.Play();


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
