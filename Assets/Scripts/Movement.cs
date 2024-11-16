using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float HInput;
    public float speed;
    public float jumpPow = 15f;
    public bool isFacingRight;
    private bool isRunning;
    private Animator animator;

    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        PlayerWalk();
        PlayerRun();
        PlayerJump();

        Flipcharacter();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(HInput * speed, rb.velocity.y);
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
   
    public void Flipcharacter()
    {
        if(isFacingRight && HInput > 0f || !isFacingRight && HInput < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void PlayerWalk()
    {
        HInput = Input.GetAxisRaw("Horizontal");

        if (HInput != 0)
        {
            animator.SetBool("isWalking", true);
        }
        if (HInput == 0 || isRunning == true)
        {
            animator.SetBool("isWalking", false);
        }
    }
    public void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&& HInput != 0)
        {
            speed = speed * 1.5f;
            isRunning = true;
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 1.5f;
            isRunning = false;
            animator.SetBool("isRunning", false);
        }
    }
    public void PlayerJump()
    {
        if (Input.GetButton("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPow);
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
        else if(!isGrounded())
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
        }
    }
     
}
