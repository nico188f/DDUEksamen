using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//kilde: https://medium.com/@yonem9/create-an-unity-inventory-part-1-basic-data-model-3b54451e25ec
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;

    public ItemType itemType;

    [Tooltip("If set to 0 it cant be sold.")]
    public int price;

    public int stackAmount;

    [TextAreaAttribute]
    public string description;
}

public enum ItemType{
    Placeble,
    Tool
}
