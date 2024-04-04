using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float jumpForce;
    public LayerMask obstacleLayer;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isJumping = false;
    private float jumpCooldown = 1f;
    private float jumpTimer = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Engeli algýla ve zýpla
        if (Physics2D.Raycast(transform.position, Vector2.right, 1f, obstacleLayer) && !isJumping)
        {
            Jump();
        }

        // Düþmaný hedefe doðru hareket ettir
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //if (rb.velocity.x > 0.1f)
        //{
        //    // Saða hareket ediyorsa sprite'ý orijinal durumuna getir 
        //    spriteRenderer.flipX = false;
        //}
        //else if (rb.velocity.x < -0.1f)
        //{
        //    // Sola hareket ediyorsa sprite'ý tersine çevir 
        //    spriteRenderer.flipX = true;
        //}
    }

    // Zýplama fonksiyonu
    private void Jump()
    {
        isJumping = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpTimer = jumpCooldown;
        animator.SetTrigger("Jump");
    }

    // Zýplama sonrasý cooldown süresini takip et
    private void Update()
    {
        if (isJumping)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0)
            {
                isJumping = false;
            }
        }

        
    }

    
}