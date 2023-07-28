using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MarkerDestroyer : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 15))
                {

                if (hit.transform.tag == "DestroyObject")
                 {                  
                    Destroy(hit.transform.gameObject);
                    Destroy(hit.transform.parent.gameObject);
                 }
                }
        }
    }
}
