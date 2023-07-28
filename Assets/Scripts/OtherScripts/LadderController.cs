using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    public float speed = 5.0f;

    private CharacterController movement;
    private Vector3 moveDirection = Vector3.zero;


    private void Start()
    {
        movement = GetComponent<CharacterController>();
    }

    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        movement.Move(moveDirection * Time.deltaTime);
    }
}
