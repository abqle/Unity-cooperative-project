using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    public float groundDrag;
    public float height;
    private bool grounded = true;

    public Transform orientation;

    float horizInput;
    float vertInput;

    Vector3 moveDirection;
    public LayerMask whatIsGround;
    CapsuleCollider capsuleCollider;
    Rigidbody rb;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    
    void FixedUpdate()
    {
        PlayerMovement();
    }

    void Update()
    {
        GetInput();
        SpeedControl();
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Speed = 14f;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            Speed = 7f;


        grounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.5f, whatIsGround);

        Debug.Log(Speed);

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void GetInput()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMovement()
    {
        moveDirection = orientation.forward * vertInput + orientation.right * horizInput;
        
        rb.AddForce(moveDirection.normalized * Speed * 10f);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > Speed)
        {
            Vector3 limitedVel = flatVel.normalized * Speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }

    

}