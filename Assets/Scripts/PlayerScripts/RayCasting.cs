using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class RayCasting : MonoBehaviour
{
    public Transform point1;
    public Transform point12;
    public Transform point2;
    public Transform point22;
    public Transform point3;
    public Transform point32;
    public Transform point4;
    public Transform point42;
    public Transform point5;
    public Transform point52;
    public Transform point6;
    public Transform point62;
    public Transform OXZYPointer;
    private Vector3 X1 = new Vector3(0f, 0f, 0f);
    private Vector3 X2 = new Vector3(0f, 0f, 0f);
    private Vector3 X3 = new Vector3(0f, 0f, 0f);
    public Material lineMat;
    public int Distance;
    public TextMeshPro DistanceOXText;
    public TextMeshPro DistanceOxText;
    public TextMeshPro DistanceOYText;
    public TextMeshPro DistanceOyText;
    public TextMeshPro DistanceOZText;
    public TextMeshPro DistanceOzText;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray2 = new Ray(transform.position, transform.forward);
        Ray ray3 = new Ray(transform.position, -transform.forward);
        Ray ray4 = new Ray(transform.position, transform.right);
        Ray ray5 = new Ray(transform.position, -transform.right);
        Ray ray6 = new Ray(transform.position, transform.up);
        Ray ray7 = new Ray(transform.position, -transform.up);

        RaycastHit hit;
        if ((Input.GetKey(KeyCode.LeftAlt)) && (Input.GetMouseButtonDown(0)) && Physics.Raycast(ray, out hit))
        {
            X1 = hit.point;
            //Debug.Log("X2:" + point1.position.x + "Y2:" + point1.position.y + "Z2:" + point1.position.z);
            //Debug.Log("X1: " + X1.x + " Y1: " + X1.y + " Z1: " + X1.z);
            OXZYPointer.transform.position = new Vector3(X1.x, X1.y, X1.z);

        }
        float distX = Vector3.Distance(X1, point3.position);
        float distx = Vector3.Distance(X1, point4.position);
        float distY = Vector3.Distance(X1, point5.position);
        float disty = Vector3.Distance(X1, point6.position);
        float distZ = Vector3.Distance(X1, point1.position);
        float distz = Vector3.Distance(X1, point2.position);

      //  print("Distance to other: " + (distX / 2.54) * 1000);
       // print("Distance to other: " + (distx / 2.54) * 1000);
       // print("Distance to other: " + (distY / 2.54) * 1000);
        //print("Distance to other: " + (disty / 2.54) * 1000);
       // print("Distance to other: " + (distZ / 2.54) * 1000);
       // print("Distance to other: " + (distz / 2.54) * 1000);
        DistanceOXText.text = Distance.ToString(string.Format("{0:0,00}", ((distX / 2.54) * 100)));
        DistanceOxText.text = Distance.ToString(string.Format("{0:0,00}", ((distx / 2.54) * 100)));
        DistanceOYText.text = Distance.ToString(string.Format("{0:0,00}", ((distY / 2.54) * 100)));
        DistanceOyText.text = Distance.ToString(string.Format("{0:0,00}", ((disty / 2.54) * 100)));
        DistanceOZText.text = Distance.ToString(string.Format("{0:0,00}", ((distZ / 2.54) * 100)));
        DistanceOzText.text = Distance.ToString(string.Format("{0:0,00}", ((distz / 2.54) * 100)));
        RaycastHit hit1;
        if (Physics.Raycast(ray2, out hit1))
        {
            point1.position = hit1.point;
            //pointer12.position = new Vector3 (( pointer1.position.x), ( pointer1.position.y), ((pointer2.position.z + OXZYPointer.position.z) / 2));         

        }
        if (Physics.Raycast(ray3, out hit1))
        {
            point2.position = hit1.point;
            //pointer22.position = new Vector3(pointer2.position.x, pointer2.position.y, pointer2.position.z/2 );
        }
        if (Physics.Raycast(ray4, out hit1))
        {
            point3.position = hit1.point;
            //pointer32.position = new Vector3((pointer3.position.x / 2), (pointer3.position.y), (pointer3.position.z));
        }
        if (Physics.Raycast(ray5, out hit1))
        {
            point4.position = hit1.point;
            //pointer42.position = new Vector3((pointer4.position.x / 2), (pointer4.position.y), (pointer4.position.z));
        }
        if (Physics.Raycast(ray6, out hit1))
        {
            point5.position = hit1.point;
            //pointer52.position = new Vector3((pointer5.position.x), (pointer5.position.y / 2), (pointer5.position.z));
        }
        if (Physics.Raycast(ray7, out hit1))
        {
            point6.position = hit1.point;
            //pointer62.position = new Vector3((pointer6.position.x), (pointer6.position.y / 2), (pointer6.position.z));
        }

    }
    void OnRenderObject()
    {


        OXZYPointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
        float dist = Vector3.Distance(X1, point1.position);
        Vector3 lineEnd1 = new Vector3(X1.x + 10, X1.y, X1.z);

        {
            GL.PushMatrix();
            GL.Begin(GL.LINES);
            lineMat.SetPass(0);
            GL.Vertex(OXZYPointer.transform.position);
            GL.Vertex(lineEnd1);
            GL.End();
            GL.PopMatrix();
        }
        OXZYPointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
        Vector3 lineEnd2 = new Vector3(X1.x - 10, X1.y, X1.z);
        {
            GL.PushMatrix();
            GL.Begin(GL.LINES);
            lineMat.SetPass(0);
            GL.Vertex(OXZYPointer.transform.position);
            GL.Vertex(lineEnd2);
            GL.End();
            GL.PopMatrix();
        }
        OXZYPointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
        Vector3 lineEnd3 = new Vector3(X1.x, X1.y + 10, X1.z);
        {
            GL.PushMatrix();
            GL.Begin(GL.LINES);
            lineMat.SetPass(0);
            GL.Vertex(OXZYPointer.transform.position);
            GL.Vertex(lineEnd3);
            GL.End();
            GL.PopMatrix();
        }
        OXZYPointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
        Vector3 lineEnd4 = new Vector3(X1.x, X1.y - 10, X1.z);
        {
            GL.PushMatrix();
            GL.Begin(GL.LINES);
            lineMat.SetPass(0);
            GL.Vertex(OXZYPointer.transform.position);
            GL.Vertex(lineEnd4);
            GL.End();
            GL.PopMatrix();
        }
        OXZYPointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
        Vector3 lineEnd5 = new Vector3(X1.x, X1.y, X1.z + 10);
        {
            GL.PushMatrix();
            GL.Begin(GL.LINES);
            lineMat.SetPass(0);
            GL.Vertex(OXZYPointer.transform.position);
            GL.Vertex(lineEnd5);
            GL.End();
            GL.PopMatrix();
        }
        OXZYPointer.transform.position = new Vector3(X1.x, X1.y, X1.z);
        Vector3 lineEnd6 = new Vector3(X1.x, X1.y, X1.z - 10);
        {
            GL.PushMatrix();
            GL.Begin(GL.LINES);
            lineMat.SetPass(0);
            GL.Vertex(OXZYPointer.transform.position);
            GL.Vertex(lineEnd6);
            GL.End();
            GL.PopMatrix();
        }
    }
}