 using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamCenterRay : MonoBehaviour
{

    [SerializeField] private Camera _fpsCamera;
    private CamCenterRay _ray;
    private RaycastHit _hit;
    private float _maxDistanceRay;   
    [SerializeField] GameObject Pointer;
    [SerializeField] GameObject Pointer2;
    [SerializeField] GameObject Sphere;
    [SerializeField] GameObject Sphere2;
    [SerializeField] GameObject Sphere3;
    [SerializeField] GameObject Sphere4;
    [SerializeField] GameObject Sphere5;
    [SerializeField] GameObject Sphere6;
    [SerializeField] GameObject Sphere7;
    [SerializeField] GameObject Sphere8;
    [SerializeField] GameObject Sphere9;
    [SerializeField] GameObject Sphere0;
    [SerializeField] GameObject Marker;
    

    private Vector3 X1 = new Vector3(0f, 0f, 0f);
    private Vector3 X2 = new Vector3(0f, 0f, 0f);
    private Vector3 X11 = new Vector3(0f, 0f, 0f);
    private Vector3 X12 = new Vector3(0f, 0f, 0f);
    private Vector3 X13 = new Vector3(0f, 1f, 0f);

    public int Distance;
    private Interactable previousInteractable;
    [SerializeField] Text DistanceText;

    
    void Update()
    {
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow); 
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            var interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                if (interactable != this && interactable != previousInteractable)
                {

                    print("OnHoverEnter");
                    previousInteractable = interactable;
                }
            }
            else 
            if (previousInteractable != null)
            {
                print("OnHoverExit");
                previousInteractable = null;
            }
        }
        
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))

        {
            X1 = hit.point;           
           
            Debug.Log("X1: " + X1.x + " Y1: " + X1.y + " Z1: " + X1.z);
            Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
            Debug.DrawLine(X1, X1 + hit.normal * 5f, Color.red);
            
        }
        
        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit))

        {
            X2 = hit.point;

            Debug.Log("X2: " + X2.x + " Y2: " + X2.y + " Z2: " + X2.z);           
            Pointer2.transform.position = new Vector3(X2.x, X2.y, X2.z);
            Debug.DrawLine(X2, X2 + hit.normal * 100f, Color.yellow);
        }

        if (Input.GetMouseButtonDown(2) && Physics.Raycast(ray, out hit))

        {
            
            float dist = Vector3.Distance(X1, X2);
            print("Distance to other: " + dist/2);
            DistanceText.text = Distance.ToString() + dist/2;
        }
        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha0)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

            GameObject childObject = Instantiate(Sphere0, X11, Quaternion.FromToRotation(X13, X12)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }

        if  (Input.GetKeyDown(KeyCode.Alpha0) && Physics.Raycast(ray, out hit))

        {
            X12 = hit.normal;
            X11 = hit.point;

            GameObject childObject = Instantiate(Marker, X11, Quaternion.FromToRotation(X13,X12)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
            Debug.Log("X1: " + X13 + " Z2: " + X12);
            
        }
        



        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha1)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;
            GameObject childObject = Instantiate(Sphere, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        
        }

        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha2)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

           
            GameObject childObject = Instantiate(Sphere2, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }
        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha3)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

            
            GameObject childObject = Instantiate(Sphere3, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }
        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha4)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

            
            GameObject childObject = Instantiate(Sphere4, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform); ;
        }
        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha5)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

            GameObject childObject = Instantiate(Sphere5, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }
        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha6)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

            GameObject childObject = Instantiate(Sphere6, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }
        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha7)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

            GameObject childObject = Instantiate(Sphere7, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }
        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha8)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

            GameObject childObject = Instantiate(Sphere8, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }
        if ((Input.GetMouseButton(0)) && (Input.GetKeyDown(KeyCode.Alpha9)) && Physics.Raycast(ray, out hit))
        {
            X11 = hit.point;

            GameObject childObject = Instantiate(Sphere9, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }

       
    }

}