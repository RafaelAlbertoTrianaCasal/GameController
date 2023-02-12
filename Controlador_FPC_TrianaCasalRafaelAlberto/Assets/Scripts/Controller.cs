using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;

    public float gravity = -9.8f;

    public float jumpHeight = 3;

    public Transform ground;
    public float gDistance = 0.3f;
    public LayerMask gMask;

    Vector3 velocity;

    bool isGrounded;

    void Start()
    {
        
    }

    
    void Update()
    {

        isGrounded = Physics.CheckSphere(ground.position,gDistance,gMask);

        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
