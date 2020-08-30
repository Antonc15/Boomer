using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Game Objects")]
    public Animator playerAnimator;
    public Transform groundTrigger;

    [Header("Movement Speeds")]
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float crawlSpeed;

    [Header("Wall Running")]
    public float wallRunSpeed;
    public float maxWallRunTime;

    [Header("Sliding")]
    public float minSlideVelocity;
    public float maxSlideVelocity;

    [Header("Wall Jump")]
    public float maxWallJumpVelocity;
    public float wallJumpLimit;

    [Header("Jumping")]
    public float jumpVelocity;

    // Private Variable \\
    Rigidbody rb;
    bool isCrouching;
    bool isSprinting;
    bool isGrounded;
    float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputHandler();
        DetectGround();
        Movement();
    }

    void InputHandler()
    {
        // Jump \\
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            }
        }

        SprintAndCrouch();
    }
    
    void SprintAndCrouch()
    {
        //****************
        // This series of scripts makes it so that
        // the crouch button when pressed always has authority over the sprint
        // If you are sprinting and press the crouch button, you will CROUCH!
        //****************

        // Crouch \\
        if (Input.GetButtonDown("Crouch"))
        {
            if (isSprinting)
            {
                isCrouching = true;
                isSprinting = false;
            }
            else
            {
                isCrouching = true;
            }
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;

            if (Input.GetButton("Sprint"))
            {
                isSprinting = true;
            }
        }

        // Sprint \\
        if (Input.GetButtonDown("Sprint"))
        {
            if (!isCrouching)
            {
                isSprinting = true;
            }
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            isSprinting = false;
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpVelocity);
    }

    void DetectGround()
    {
        Collider[] hitColliders = Physics.OverlapSphere(groundTrigger.position, 0.49f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (!hitColliders[i].isTrigger && hitColliders[i].gameObject.layer != LayerMask.NameToLayer("Player") && hitColliders[i].gameObject.layer != LayerMask.NameToLayer("Bomb"))
            {
                isGrounded = true;
                break;
            }
            else
            {
                isGrounded = false;
            }
        }
    }

    void Movement()
    {
        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }

        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }

        if (!isCrouching & !isSprinting)
        {
            currentSpeed = walkSpeed;
        }
    }
}
