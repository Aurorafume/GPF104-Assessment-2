/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float jumpTime = 0.5f;
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public int extraJumps = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
    }

    void Update()
    {
        // If the player is on the ground, reset the number of jumps
        if (isGrounded)
        {
            extraJumps = 1;
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
            rb.velocity = Vector2.up * jumpForce;
        }

        // Let player jump again if they have extra jumps
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

    }
}*/