using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERALOCKER : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    public Transform Player;
    Quaternion originRotation;
    //float angleHorizontal;
    //float angleVertical;
    float mouseSens = 50;

    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.visible == false)
        {

            //mouseY = Mathf.Clamp(-mouseY, -90, 90);
            mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;


            Player.Rotate(mouseX * new Vector3(0, 1, 0));
            //Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
            transform.Rotate(-mouseY * new Vector3(-mouseY, -90, 90));
        }
        //angleHorizontal = Input.GetAxis("Mouse X") * mouseSens;
        //angleVertical = Input.GetAxis("Mouse Y") * mouseSens;

        //angleVertical = Mathf.Clamp(angleVertical, -60, 60);

        //Quaternion rotationY  = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
        //Quaternion rotatitonX = Quaternion.AngleAxis(-angleVertical, Vector3.right);

        //transform.rotation = originRotation * rotationY * rotatitonX;
    }

}
