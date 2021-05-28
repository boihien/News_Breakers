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
    private int jumpCount;
    
    public Animator hero;
    
    public AudioSource pickedUp;
    public AudioSource jumpSound;
    
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

    private void Start()
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
        
        //Tells charcater animation to walk left, right, or idle
        hero.SetFloat("Walk",Input.GetAxis("Horizontal"));
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        
        if (isJumping)
        {
            jumpSound.Play(0);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            hero.SetInteger("Dir", 1);
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            hero.SetInteger("Dir", 0);
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
            jumpCount--;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; //Inverse
        transform.Rotate(0f, 180f, 0f);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Armor") {
            if (Input.GetKeyDown("space") )  {
                Destroy(other.gameObject);
                hero.SetBool("Armored", true);
                pickedUp.Play(0);
            }
        }
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {
        float timer = 0;

        while (knockDur > timer) {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        }

        yield return 0;
    }
}
