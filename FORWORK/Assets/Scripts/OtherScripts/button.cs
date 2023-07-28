using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class button : MonoBehaviour
{
    public InputField Field;
    public Text text;
    public GameObject MarkerV100;
    public GameObject MarkerV1001;
    //public string X;

    public void MyText()
    {
        //X = MarkerV100.name;
        //X = Field.text;
        text.text = gameObject.name;
        MarkerV100.name = text.text;

    }

}
