using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    
    private float xDirection = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        UpdateAnimation();
    }

    private void Move() {
        xDirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xDirection * moveSpeed, rb.velocity.y);
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimation() {
        if (xDirection > 0f)
        {
            sprite.flipX = false;
            anim.SetBool("running", true);
        }
        else if (xDirection < 0f)
        {
            sprite.flipX = true;
            anim.SetBool("running", true);
        } else
        {
            anim.SetBool("running", false);
        }
    }
}
