using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public ParticleSystem Dust;

    public bool groundParticlePlay = false;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public bool isMoving;
    private Rigidbody2D rb;
    private float moveInput;

    public Animator Anim;
    public SpriteRenderer Spritectr;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Update() {
        // Dust

        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            isMoving = true;
            Anim.SetBool("isMoving", true);
        } else
        {
            isMoving = false;
            Anim.SetBool("isMoving", false);
        }

        if (isMoving == true)
        {
            Dust.Play();
        }

        if (isGrounded == false)
        {
            Dust.Stop();
        }

        // Jumping       
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }


}
