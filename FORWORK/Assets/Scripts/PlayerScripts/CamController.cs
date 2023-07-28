 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CamController : MonoBehaviour
{
    Quaternion originRotation;
    private float mouseX;
    private float mouseY;
    float angleHorizontal;
    float angleVertical;
    public float cameraSpeed = 0.125f;

    private int cameraHeight = new int();
    private const int LOW_LIMIT_FOR_CAMERA = 0;
    private const int HIGH_LIMIT_FOR_CAMERA = 100;

    [Header("Чувствительность мыши")]
    public float sensitivityMouse = 10f;

    public Transform Player;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //originRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void moveCameraUp()
    {
        Vector3 lerpPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), cameraSpeed);
        transform.position = lerpPosition;
    }

    public void moveCameraDown()
    {
        Vector3 lerpPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), cameraSpeed);
        transform.position = lerpPosition;
    }


    private void Update()
    {
        if (Cursor.visible == false)
        {
            angleHorizontal += Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime;
            angleVertical += Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;
            angleVertical = Mathf.Clamp(angleVertical, -90, 90);
            Quaternion rotationY = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
            Quaternion rotationX = Quaternion.AngleAxis(-angleVertical, Vector3.right);


            Player.rotation = (rotationY);

            transform.rotation = (rotationY * rotationX);
        }


        //if (Input.GetKey(KeyCode.UpArrow) && cameraHeight < HIGH_LIMIT_FOR_CAMERA) { moveCameraUp(); cameraHeight++; }
        //if (Input.GetKey(KeyCode.DownArrow) && cameraHeight > LOW_LIMIT_FOR_CAMERA) { moveCameraDown(); cameraHeight--; }
        
    }
}