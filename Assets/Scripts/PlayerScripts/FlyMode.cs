using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class FlyMode : MonoBehaviour
{
  
    [SerializeField] CharacterController Player;
    [SerializeField] GameObject Capsule;
    public bool isColliderActive;

    private void Start()
    {
        Collider col = Capsule.GetComponent<CapsuleCollider>();
        col.GetComponent<CapsuleCollider>();
        col.enabled = true;
        Capsule.GetComponent<Rigidbody>().useGravity = true;

        Player = GetComponent<CharacterController>();
        
    }
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.H))
        {
            isColliderActive = !isColliderActive;
            if (isColliderActive)
            {
                Collider col = Capsule.GetComponent<CapsuleCollider>();
                col.GetComponent<CapsuleCollider>();
                col.enabled = false;
                Capsule.GetComponent<Rigidbody>().useGravity = false;
                Capsule.GetComponent<CapsuleCollider>().enabled = false;

                Player.detectCollisions = false;

            }
            else
            {
                Collider col = Capsule.GetComponent<CapsuleCollider>();
                col.GetComponent<CapsuleCollider>();
                col.enabled = true;
                Capsule.GetComponent<Rigidbody>().useGravity = true;
                Capsule.GetComponent<CapsuleCollider>().enabled = true;

                Player.detectCollisions = true;
            }

        }
    }
}
