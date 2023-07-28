using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class SaveTxtForRedField : MonoBehaviour
{
    public InputField FieldRed;
    



    void Start()

    {
        string txt = "";
        txt = PlayerPrefs.GetString("TestB", "");
        txt = txt.Replace(".", "\n");
        FieldRed.text = txt;
      
    }


    public void End(GameObject obj)
    {
        string text = "";
        string tosave = "";
        text = obj.GetComponent<InputField>().text;
        tosave = text.Replace("\n", ".");
        PlayerPrefs.SetString("TestB", tosave);
        PlayerPrefs.Save();
    }
}
