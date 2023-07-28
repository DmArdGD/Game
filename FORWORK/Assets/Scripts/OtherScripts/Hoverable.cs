 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverable : MonoBehaviour
{
    public string NAME;
    public GameObject Object;
    public void OnMouseEnter()
    {
        UIManag.SetOnHoverText(gameObject.name);
        NAME = gameObject.name;
    }
    private void OnMouseExit()
    {
        UIManag.OffOnHoverText();
    }
    
   
}

