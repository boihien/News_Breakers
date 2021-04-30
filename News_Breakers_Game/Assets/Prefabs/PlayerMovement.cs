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
    public int maxJumpCount;
    public Animator hero;
    
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isGrounded;
    private bool isJumping = false;
    private int jumpCount;
    
    //Awake is called after all objects are initialized. Called in random
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        jumpCount = maxJumpCount;
    }

    //Better for handling physics
    void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        //Move
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Inputs
        ProcessInputs();

        //Animate
        //Animate();
        hero.SetFloat("Walk",Input.GetAxis("Horizontal"));
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
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
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
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
