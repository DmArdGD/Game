using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;
using TMPro;

public class ScaleTry : MonoBehaviour
{

    [SerializeField] private Camera _fpsCamera;
    private CamCenterRay _ray;
    private RaycastHit _hit;
    private float _maxDistanceRay;
    [SerializeField] GameObject Pointer;
    // [SerializeField] GameObject Point;
    [SerializeField] GameObject Pointer2;
    [SerializeField] GameObject Sphere;
    [SerializeField] GameObject Sphere2;
    [SerializeField] GameObject Sphere3;
   // [SerializeField] GameObject Marker;
   // [SerializeField] GameObject Otvod;
    [HideInInspector] public GameObject SelectPipe;
    //public InputField fieldx, fieldy, fieldz;
    private Vector3 X1 = new Vector3(0f, 0f, 0f);
    float X3 = 0f;
    private Vector3 X2 = new Vector3(0f, 0f, 0f);
    private Vector3 X11 = new Vector3(0f, 0f, 0f);
    private Vector3 X12 = new Vector3(0f, 0f, 0f);
    private Vector3 X13 = new Vector3(0f, 1f, 0f);
    private Vector3 X14 = new Vector3(0f, 1f, 0f);
    private Vector3 X15 = new Vector3(1f, 0f, 0f);
    private Vector3 X16 = new Vector3(0f, 0f, 1f);
    public Material lineMat;
   // public GameObject[] points;
    // [SerializeField] GameObject Point1;
    public float cor_delay = 2f;
    public int Distance;
    private Interactable previousInteractable;
    [SerializeField] TMP_Text DistanceText;
    // [SerializeField] Text CoordinateText;

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;




        if (Physics.Raycast(ray, out hit, 10))
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


       
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit)))
        {
            X1 = hit.point;
            Debug.Log("X1: " + X1.x + " Y1: " + X1.y + " Z1: " + X1.z);
            Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
            
        }
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit)))
        {
            X2 = hit.point;
            Debug.Log("X2: " + X2.x + " Y2: " + X2.y + " Z2: " + X2.z);
            Pointer2.transform.position = new Vector3(X2.x, X2.y, X2.z);
        }
        if (Input.GetMouseButtonDown(2))
        {
            float dist = Vector3.Distance(X1, X2);
            print("Distance to other: " + (dist / 2.54) * 1000);
            DistanceText.text = Distance.ToString(string.Format("{0:0,0}", (dist / 2.54) * 100));
            //CoordinateText.text = ("X1: " + X1.x + " Y1: " + X1.y + " Z1: " + X1.z);
            Invoke("UnActiveDistance", 5);
        }


        // Изменение длины трубы

        //if (fieldy.text == null || fieldy.text == string.Empty)
        // Marker.transform.localScale = new Vector3(0.057f, 0.001f, 0.057f);
        //}
        //else
        //Marker.transform.localScale = new Vector3(0.057f, ((float)Double.Parse(fieldy.text)) / 1000000, 0.057f);

        //if (fieldz.text == null || fieldz.text == string.Empty)
        //Otvod.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        //else
        //Otvod.transform.localRotation = Quaternion.AngleAxis(((float)Double.Parse(fieldz.text)), X14);


        // Точки-маркеры используются для отмечения проблемных мест

        if ((Input.GetKey(KeyCode.LeftShift) && (Input.GetKeyDown(KeyCode.Alpha1)) && Physics.Raycast(ray, out hit)))
        {
            X11 = hit.point;
            GameObject childObject = Instantiate(Sphere, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }

        if ((Input.GetKey(KeyCode.LeftShift) && (Input.GetKeyDown(KeyCode.Alpha2)) && Physics.Raycast(ray, out hit)))
        {
            X11 = hit.point;
            GameObject childObject = Instantiate(Sphere2, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }
        if ((Input.GetKey(KeyCode.LeftShift) && (Input.GetKeyDown(KeyCode.Alpha3)) && Physics.Raycast(ray, out hit)))
        {
            X11 = hit.point;
            GameObject childObject = Instantiate(Sphere3, X11, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        }

        // ставит отвод 

        //if ((Input.GetKey(KeyCode.LeftShift) && (Input.GetKeyDown(KeyCode.Alpha4)) && Physics.Raycast(ray, out hit)))
        //{

        //    X12 = hit.normal;
        //    X11 = hit.point;

        //    GameObject childObject = Instantiate(Otvod, X11, Quaternion.AngleAxis(((float)int.Parse(fieldz.text)), X14)) as GameObject;
        //    childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        //}
        //float aa = (float)int.Parse(fieldz.text);
        //Vector3 bb = new Vector3(0, 1, 0);
        //Otvod.transform.rotation.ToAngleAxis(out aa, out bb);

        //if ((Input.GetKey(KeyCode.LeftShift) && (Input.GetKeyDown(KeyCode.Alpha4)) && Physics.Raycast(ray, out hit)))
        //{
        //    if (hit.transform.CompareTag("ConnectPipePoint"))
        //    {
        //        var pipePoints = GameObject.FindGameObjectsWithTag("ConnectPipePoint");
        //        for (int i = 0; i < pipePoints.Length; i++)
        //        {
        //            if (hit.transform.GetInstanceID() == pipePoints[i].transform.GetInstanceID())
        //            {
        //                X12 = hit.normal;
        //                GameObject childObject = Instantiate(Otvod, pipePoints[i].transform.position, Quaternion.FromToRotation(X13, X12) * Quaternion.AngleAxis((float)int.Parse(fieldz.text), X14)) as GameObject;
        //                childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        X12 = hit.normal;
        //        X11 = hit.point;
        //        GameObject childObject = Instantiate(Otvod, X11, Quaternion.FromToRotation(X13, X12)) as GameObject;
        //        childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
        //        Debug.Log("X1: " + X13 + " Z2: " + X12);
        //    }
        //}
        //Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
        //Point.transform.position = new Vector3(X1.x + 10, X1.y, X1.z);
        //Ray ray2 = new Ray(Pointer.transform.position, Point.transform.position);
        //RaycastHit hit2;
        //if(Physics.Raycast(ray2, out hit2))
        //{
        //    X1 = hit.point;
        //    X3 = hit2.distance;
        //    float dist = X3;
        //    print("Distance to other: " + (dist / 2.54) * 1000);
        //    DistanceText.text = Distance.ToString() + (dist / 2.54) * 1000;
        //    Invoke("UnActiveDistance", 5);
        //}
       
    }



    void OnRenderObject()
    {
        //    if (Pointer && points.Length > 0)
        //    {
        //        // Loop through each point to connect to the mainPoint
        //        foreach (GameObject point in points)
        //        {
        //            Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
        //            point.transform.position = new Vector3(X1.x + 10, X1.y, X1.z);

        //            GL.Begin(GL.LINES);
        //            lineMat.SetPass(0);
        //            GL.Vertex(Pointer.transform.position);
        //            GL.Vertex(point.transform.position);
        //            GL.End();

        //        }
        //    }
        Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
    Vector3 lineEnd1 = new Vector3(X1.x + 10, X1.y, X1.z);
        {
            GL.PushMatrix();
            GL.Begin(GL.LINES);
            lineMat.SetPass(0);
            GL.Vertex(Pointer.transform.position);
            GL.Vertex(lineEnd1);
            GL.End();
            GL.PopMatrix();
        }
Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
Vector3 lineEnd2 = new Vector3(X1.x - 10, X1.y, X1.z);
{
    GL.PushMatrix();
    GL.Begin(GL.LINES);
    lineMat.SetPass(0);
    GL.Vertex(Pointer.transform.position);
    GL.Vertex(lineEnd2);
    GL.End();
    GL.PopMatrix();

}
Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
Vector3 lineEnd3 = new Vector3(X1.x, X1.y + 10, X1.z);
{
    GL.PushMatrix();
    GL.Begin(GL.LINES);
    lineMat.SetPass(0);
    GL.Vertex(Pointer.transform.position);
    GL.Vertex(lineEnd3);
    GL.End();
    GL.PopMatrix();
}
Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
Vector3 lineEnd4 = new Vector3(X1.x, X1.y - 10, X1.z);
{
    GL.PushMatrix();
    GL.Begin(GL.LINES);
    lineMat.SetPass(0);
    GL.Vertex(Pointer.transform.position);
    GL.Vertex(lineEnd4);
    GL.End();
    GL.PopMatrix();
}
Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
Vector3 lineEnd5 = new Vector3(X1.x, X1.y, X1.z + 15);
{
    GL.PushMatrix();
    GL.Begin(GL.LINES);
    lineMat.SetPass(0);
    GL.Vertex(Pointer.transform.position);
    GL.Vertex(lineEnd5);
    GL.End();
    GL.PopMatrix();
}
Pointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
Vector3 lineEnd6 = new Vector3(X1.x, X1.y, X1.z - 15);
{
    GL.PushMatrix();
    GL.Begin(GL.LINES);
    lineMat.SetPass(0);
    GL.Vertex(Pointer.transform.position);
    GL.Vertex(lineEnd6);
    GL.End();
    GL.PopMatrix();
}
    }



    void OnPostRender()
    {
        OnRenderObject();
    }
    //void OnDrawGizmos()
    //{
    //    OnRenderObject();
    //}
    void UnActiveDistance()
    {
        DistanceText.text = "";
       // CoordinateText.text = "";
    } 
   

}
