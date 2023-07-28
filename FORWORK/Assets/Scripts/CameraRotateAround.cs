using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour
{
    Camera MainCamera;

   public GameObject target;//the target object
    private float speedMod = 0.5f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at
                          // Update is called once per frame
    void Start()
    {//Set up things on the start method
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it
    }
    void Update()
    {

        transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
    }
}
