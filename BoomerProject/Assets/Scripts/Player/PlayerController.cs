using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public float maxJumpAngle = 45;
    public float jumpVelocity = 750;
    public float moveSpeed;

    bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
        Move();
    }

    void OnCollisionStay(Collision col)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision col)
    {
        isGrounded = false;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(transform.up * rb.velocity.y);
            rb.AddForce(transform.up * jumpVelocity);
        }
    }

    void Move()
    {
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y, rb.velocity.z);
    }
}
