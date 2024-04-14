using System;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float horizontalInput;
    public float jumpPower = 3.0f;
    public float boostSpeed = 5.0f;
    public float energy = 100.0f;
    public float energyDepletionRate = 20.0f;
    public float energyRegenRate = 10.0f;
    public float maxEnergy = 50.0f;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        energy = maxEnergy;
    }

    private void Update()
    {
        if (!isDead)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            FlipSprite();

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
                AudioManager.Instance.PlaySFX("CharJump");
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && energy >= energyDepletionRate)
            {
                Boost();
            }

            if (energy < maxEnergy)
            {
                energy += energyRegenRate * Time.deltaTime;
                energy = Mathf.Clamp(energy, 0f, maxEnergy);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
        UpdateAnimator();
    }

    private void Move()
    {
        float speed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftControl) && energy >= energyDepletionRate)
        {
            speed = boostSpeed;
            energy -= energyDepletionRate * Time.deltaTime;
        }

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        isGrounded = false;
        animator.SetBool("isJumping", !isGrounded);
    }

    private void Boost()
    {
        // Implement boost functionality here
        // For example, increase speed for a short duration
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);



    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded == true;
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("die");
        moveSpeed = 0f;
        // You may want to add other death-related functionality here
    }

    public void FlipSprite()
    {

        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {

            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;


        }
    }

    public void RunSound()
    {


        AudioManager.Instance.PlaySFX("Run");
    }



  

}

