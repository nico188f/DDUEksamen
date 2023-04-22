using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//kilde: https://medium.com/@yonem9/create-an-unity-inventory-part-1-basic-data-model-3b54451e25ec
[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Object/Create New Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;

    public ItemType itemType;

    
    public int price;

    [Tooltip("If set to 0 it cant be sold.")]
    public int sellPrice;

    public int stackAmount;

    [TextAreaAttribute]
    public string description;

    [Header("Building")]
    public GameObject Building;

    
}

public enum ItemType
{
    Utility,
    Placeble,
    Tool
}
