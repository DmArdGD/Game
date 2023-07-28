using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{   
    public float Speed = 15;
    public float JumpForce = 300f;  
    public Rigidbody _rb;
    public GameObject MainCamera;
    private Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
      
    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        if (Input.GetKey(KeyCode.W))
            _rb.AddForce(MainCamera.transform.forward * Speed);
        else if (Input.GetKey(KeyCode.S))
            _rb.AddForce(-MainCamera.transform.forward * Speed);
        else if (Input.GetKey(KeyCode.A))
            _rb.AddForce(-MainCamera.transform.right * Speed);
        else if (Input.GetKey(KeyCode.D))
            _rb.AddForce(MainCamera.transform.right * Speed);
        else
            if(Input.GetKey(KeyCode.Space))
            _rb.AddForce(Vector3.up * Speed);
        else
            if (Input.GetKey(KeyCode.LeftControl))
            _rb.AddForce(Vector3.down * Speed);

        else
            _rb.velocity = new Vector3(0f, 0f, 0f);
    }

}
