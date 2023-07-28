using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLayers : MonoBehaviour
{
    public GameObject b53;
    private bool b53_1 = true;
    //public GameObject b54;
    //private bool b54_1 = true;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            b53_1 = !b53_1;
            b53.SetActive(b53_1);
        }
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    b54_1 = !b54_1;
        //    b54.SetActive(b54_1);
        //}

    }
}
