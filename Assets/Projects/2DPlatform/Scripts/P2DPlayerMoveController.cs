using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class P2DPlayerMoveController : MonoBehaviour
{
    public float moveForce = 10;
    public float jumpForce = 20;
    public float bounceForce = 20;
    public float extraGravity = 10;

    private float h;
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool isJump;
    private List<Transform> contacts = new List<Transform>();
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundedMove();      
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


        Vector3 inputVector = new Vector3(h, 0);
        Vector3 force = inputVector * moveForce;
        force.y = rb.velocity.y;

        rb.AddForce(inputVector * moveForce);

        // Apply extra gravity. Maybe you only want this while jumping.
        rb.velocity += Vector2.down * extraGravity * Time.fixedDeltaTime;

        isJump = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bouncy")
        {
            rb.velocity = (Vector2)collision.transform.up * bounceForce;
        }

    }



    private bool GetIsGrounded()
    {
        return contacts.Count > 0;
    }
}
