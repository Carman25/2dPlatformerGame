using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PC2 : MonoBehaviour
{
    private float horizontal;
    public float speed, jp;
    SpriteRenderer spriteRenderer;
    Animator animator;
    bool canMove;
    public bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        // speed = 2f;
        // jp = 8f;
        animator = GetComponent<Animator>();

    }
    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jp);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void FixedUpdate(){
        if(isGrounded() == false){
            rb.velocity = new Vector2(horizontal * speed * 0.7f, rb.velocity.y); 
            animator.SetBool("isMoving", false);
        }
        else{
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if(horizontal != 0){
                animator.SetBool("isMoving", true);
            }
            else{
                animator.SetBool("isMoving", false);
            } 
        }

    }
    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip(){
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            spriteRenderer.flipX = !isFacingRight;
            isFacingRight = !isFacingRight;
            
        }
    }

}

