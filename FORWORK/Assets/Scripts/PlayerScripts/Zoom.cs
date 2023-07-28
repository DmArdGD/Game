using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour
{
    public Camera MainCam;
 
    public Camera PhotoCam;

    void Update()
    {
        
            // -------------------Code for Zooming Out------------
            if (Input.GetAxis("Mouse ScrollWheel") < 0) 
            {
                if (MainCam.fieldOfView <= 60)
                    MainCam.fieldOfView += 2;
                if (MainCam.orthographicSize <= 20)
                    MainCam.orthographicSize += 0.5f;

            }
            // ---------------Code for Zooming In------------------------
            if (Input.GetAxis("Mouse ScrollWheel") > 0) 
            {
                if (MainCam.fieldOfView > 30)
                    MainCam.fieldOfView -= 2;
                if (MainCam.orthographicSize >= 1)
                    MainCam.orthographicSize -= 0.5f;
            }

            // -------Code to switch camera between Perspective and Orthographic--------
            if (Input.GetKeyUp(KeyCode.B))
            {
                if (MainCam.orthographic == true)
                    MainCam.orthographic = false;
                else
                    MainCam.orthographic = true;
            }


            // -------------------Code for Zooming Out------------
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (PhotoCam.fieldOfView <= 125)
                    PhotoCam.fieldOfView += 2;
                if (PhotoCam.orthographicSize <= 20)
                    PhotoCam.orthographicSize += 0.5f;

            }
            // ---------------Code for Zooming In------------------------
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (PhotoCam.fieldOfView > 2)
                    PhotoCam.fieldOfView -= 2;
                if (PhotoCam.orthographicSize >= 1)
                    PhotoCam.orthographicSize -= 0.5f;
            }

            // -------Code to switch camera between Perspective and Orthographic--------
            if (Input.GetKeyUp(KeyCode.B))
            {
                if (PhotoCam.orthographic == true)
                    PhotoCam.orthographic = false;
                else
                    PhotoCam.orthographic = true;
            }
        
    }
}