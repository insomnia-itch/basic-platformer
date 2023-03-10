using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private AudioSource jumpSFX;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    private enum MovementState { idle, running, jumping, falling }
    
    private float xDirection = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Don't allow movement if player has died
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            Move();
            Jump();
        }
        UpdateAnimation();
    }

    private void Move() {
        xDirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xDirection * moveSpeed, rb.velocity.y);
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSFX.Play();
        }
    }

    private void UpdateAnimation() {
        MovementState state;
        if (xDirection > 0f)
        {
            sprite.flipX = false;
            state = MovementState.running;
        }
        else if (xDirection < 0f)
        {
            sprite.flipX = true;
            state = MovementState.running;
        } else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        } else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        // casting to int
        anim.SetInteger("state", (int) state);
    }

    private bool IsGrounded() {
        // like a RayCast
        //  a quasi collider just for the purpose of feet touching group
        // last arg is a layer that overlaps with this boxcast
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
