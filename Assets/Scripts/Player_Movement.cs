using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Animator animator;

    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;
    float horizontalMove = 0f;
    public float jumpForce = 10f;
    public float jumpTime = 0.5f;
    private Collider2D playerCollider;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public int extraJumps = 1;
    private bool isJumping;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        Flip();

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);    
        }

        // If the player is on the ground, reset the number of jumps
        if (isGrounded)
        {
          
            extraJumps = 1;
           
            isGrounded = true;
            
        }

        // List all floor objects in parent element
        Collider2D[] colliders = GameObject.Find("Level").GetComponentsInChildren<Collider2D>();

        // Check if player collider is touching any of these colliders
        bool touching = false;
        foreach (Collider2D c in colliders)
        {
            if (c.IsTouching(playerCollider))
            {
                touching = true;
                break;
            }
        }

        // Only let ground check turn true if player is on game object "Level"
        isGrounded = touching;

        // Press space to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpSoundEffect.Play();
            rb.velocity = Vector2.up * jumpForce;
           
        }

        // Let player jump again if they have extra jumps
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {   
        isFacingRight = false;

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}