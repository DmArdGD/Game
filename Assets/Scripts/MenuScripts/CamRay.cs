using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CamRay : MonoBehaviour
    {

    public Transform Pointer;
    public Selectable CurrentSelectable;

        void LateUpdate()
        {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);


            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
            Pointer.position = hit.point;
          
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
              if (selectable)
              {
                if(CurrentSelectable && CurrentSelectable != selectable)
                {
                    CurrentSelectable.Deselect();
                }
                CurrentSelectable = selectable;
                selectable.Select();
              }
               else
               {
                 if (CurrentSelectable)
                 {
                    CurrentSelectable.Deselect();
                    CurrentSelectable = null;
                 }
               }
                                  
            }
             else
        {
             if (CurrentSelectable)
             {
                CurrentSelectable.Deselect();
                CurrentSelectable = null;
             }
        }
            //if (CurrentSelectable != null ) && Input.GetKeyDown(KeyCode.L)
            //    {

            //    }
             
           
             

        //if (Input.GetMouseButtonDown(2) && Physics.Raycast(ray, out hit))

        //{

        //    float dist = Vector3.Distance(X1, X2);
        //    print("Distance to other: " + dist);
        //    DistanceText.text = Distance.ToString() + dist;
        //}
    }


    }

