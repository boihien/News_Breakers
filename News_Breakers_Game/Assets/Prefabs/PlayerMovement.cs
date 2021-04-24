using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    public float checkRadius;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isGrounded;
    private bool isJumping = false;

    //Awake is called after all objects are initialized. Called in random
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Better for handling physics
    void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);

        //Move
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Inputs
        ProcessInputs();

        //Animate
        Animate();

    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; //Inverse
        transform.Rotate(0f, 180f, 0f);
    }
}
