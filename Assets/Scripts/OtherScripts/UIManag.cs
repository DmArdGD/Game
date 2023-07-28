using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManag : MonoBehaviour
{
    public static TextMeshProUGUI OnHoverText;
    void Start()
    {
        OnHoverText = GameObject.Find("Canvas/ObjectNameText").GetComponent<TextMeshProUGUI>();

    }

    public static void SetOnHoverText(string objName)
    {
        OnHoverText.text = objName;
    }

    public static void OffOnHoverText()
    {
        OnHoverText.text = "";
    }
    
}
