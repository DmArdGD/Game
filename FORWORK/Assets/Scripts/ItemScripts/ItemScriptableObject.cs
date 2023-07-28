using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType {Default, Pipes, Markers}

public class ItemScriptableObject : ScriptableObject
{
   
    public string itemName;
    public GameObject itemPrefab;
    public ItemType itemType;
    public string itemDescription;
    public int maximumAmount;
    public Sprite icon; 
}
