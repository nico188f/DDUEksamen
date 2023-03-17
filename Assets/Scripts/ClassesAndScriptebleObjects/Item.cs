using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//kilde: https://medium.com/@yonem9/create-an-unity-inventory-part-1-basic-data-model-3b54451e25ec
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    

}

public enum ItemType{
    Placeble,
    Tool,
    ItemThatCanBeSold 
}
