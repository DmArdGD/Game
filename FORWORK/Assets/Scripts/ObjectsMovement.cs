using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsMovement : MonoBehaviour
{
    private Vector3 pointScreen;
    private Vector3 offset;
    private Outline outline;
    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    
    private void OnMouseDown()
    {
        pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position) ;    
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z)) ;
        outline.enabled = true;
    }
    private void OnMouseUp()
    {
        outline.enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;   
    }

}
