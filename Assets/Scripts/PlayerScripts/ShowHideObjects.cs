using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObjects : MonoBehaviour
{
    private const int ALL_LAYERS_MASK = 511;
    public LayerMask layers;
    public Camera cam;
    private GameObject inspectedPipe;
    private bool layersAreHiden = false;
    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
       
       

        if (Input.GetKeyDown(KeyCode.G) && Physics.Raycast(ray, out hit) && !layersAreHiden)
        {
            if (hit.collider.gameObject.layer == (LayerMask.NameToLayer("Pipe")))
                
            {
                //inspectedPipe = hit.transform.parent.gameObject;
                inspectedPipe = hit.collider.gameObject;
                inspectedPipe.layer = LayerMask.NameToLayer("Visible");  
                cam.cullingMask = LayerMask.GetMask("Default", "Visible");
                layersAreHiden = true;
            } 
        }
        else
        if (Input.GetKeyDown(KeyCode.G) && layersAreHiden)
        {
            inspectedPipe.layer = LayerMask.NameToLayer("Pipe");
            cam.cullingMask = ALL_LAYERS_MASK;
            layersAreHiden = false;
        }


    }



}
