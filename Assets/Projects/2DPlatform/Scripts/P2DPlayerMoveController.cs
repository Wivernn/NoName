using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[ExecuteInEditMode]
public class P2DPlayerMoveController : MonoBehaviour
{
    private float moveForce = 7;
    private float jumpForce = 12;
    // public float bounceForce = 20;
    private float extraGravity = 10;



    // Start facing right (like the sprite-sheet)
    private bool facingRight = true;
    private Animator animator;
    private float h;
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool isJump;
    private List<Transform> contacts = new();


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GroundedMove();


        // Pass in the current velocity of the RigidBody2D
        // The speed parameter of the Animator now knows
        // how fast the player is moving and responds accordingly
        if (isGrounded == true)
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


        // Check which way the player is facing 
        // and call reverseImage if neccessary
        if (h < 0 && facingRight)
            reverseImage();
        else if (h > 0 && !facingRight)
            reverseImage();

        //animator.SetFloat("V", rb.velocity.normalized.y);

       /* if (rb.velocity.y > 0)
        {

            animator.SetBool("Jumping", true);
            animator.SetBool("Falling", false);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", true);

        } */

        bool isrising = rb.velocity.y > 0;
                animator.SetBool("Jumping", isrising);
                animator.SetBool("Falling", !isrising);

        if (isGrounded == true)
        {
            animator.SetBool("Falling", false);
            animator.SetBool("Jumping", false) ;
        }

        
    }



    void GroundedMove()
    {
        h = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = GetIsGrounded();

        if (isJump && isGrounded)
        {
            rb.velocity += new Vector2(0, jumpForce);
        }
        //vector2 refers to how an object moves in a 2d space


        Vector3 inputVector = new(h, 0);
        Vector3 force = inputVector * moveForce;
        force.y = rb.velocity.y;

        //  rb.AddForce(inputVector * moveForce);
        // Apply extra gravity. Maybe you only want this while jumping.
        rb.velocity = force;
        rb.velocity += extraGravity * Time.fixedDeltaTime * Vector2.down;

        isJump = false;



    }

    void reverseImage()
    {
        // Switch the value of the Boolean
        facingRight = !facingRight;

        // Get and store the local scale of the RigidBody2D
        Vector2 theScale = rb.transform.localScale;

        // Flip it around the other way
        theScale.x *= -1;
        rb.transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckForGroundContact(collision);

        void CheckForGroundContact(Collision2D collision)
        {
            Vector2 normal = collision.GetContact(0).normal;
            float dot = Vector2.Dot(normal, Vector2.up);

            if (dot > .1f)
            {
                contacts.Add(collision.transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        contacts.Remove(collision.transform);
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.tag == "Bouncy")
         {
             rb.velocity = (Vector2)collision.transform.up * bounceForce;
         }

     } */



    private bool GetIsGrounded()
    {
        return contacts.Count > 0;
    }
}

