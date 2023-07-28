using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pipe Item", menuName = "Inventory/Items/New Pipe Item")]
public class PipeItem : ItemScriptableObject
{
    public float PipeType;


    private void Start()
    {
        itemType = ItemType.Pipes;
    }

}
