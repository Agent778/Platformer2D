using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Рух")]
    public float moveSpeed = 5f;
    private float moveInput;

    [Header("Стрибок")]
    public float jumpForce = 12f;
    public int maxJumpCount = 2;
    private int jumpCount;

    [Header("Перевірка землі")]
    public Transform groundChecker;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    private bool isGrounded;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    void Update()
    {
        // Перевіряємо чи стоїмо на землі
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, whatIsGround);

        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }

        // Рух по горизонталі
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Стрибок
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }
    }
}
