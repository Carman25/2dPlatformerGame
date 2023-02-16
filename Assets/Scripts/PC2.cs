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
    private bool canMove, canDJ;
    public bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck, landingCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        // speed = 2f;
        // jp = 8f;
        animator = GetComponent<Animator>();
        canDJ = true;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal");

        

        if(Input.GetButtonDown("Jump")){
            if(isGrounded()){
                rb.velocity = new Vector2(rb.velocity.x, jp);
                animator.SetTrigger("Jump");
                
            }
            else if(canDJ){
                rb.velocity = new Vector2(rb.velocity.x, jp * 0.8f);
                canDJ = false;
                animator.SetTrigger("Jump");
                
            }
            else{
                
            }
            
            
        }
        if(isGrounded()){
            canDJ = true;
        }

        // if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f && canDJ){
        //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.5f);
        //     canDJ = false;
        // }
    }

    void FixedUpdate(){
        if(isGrounded() == false){
            rb.velocity = new Vector2(horizontal * speed * 0.7f, rb.velocity.y); 
            animator.SetBool("isMoving", false);
            Flip(horizontal);
        }
        else{
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if(horizontal != 0){
                animator.SetBool("isMoving", true);
                Flip(horizontal);
            }
            else{
                animator.SetBool("isMoving", false);
            } 
        }

        if(isLanding()){
            animator.SetTrigger("Land");
        }

    }
    private bool isGrounded(){
        Vector2 size = new Vector2(0.05f, 0.15f);
        return Physics2D.OverlapBox(groundCheck.position, size, 0f, groundLayer);
    }

    private bool isLanding(){
        Vector2 size = new Vector2(0.05f, 2f);
        return Physics2D.OverlapBox(landingCheck.position, size, 0f, groundLayer);
    }

    private void Flip(float n){
        if(n < 0){
            spriteRenderer.flipX = true;
        }
        else if(n > 0){
            spriteRenderer.flipX = false;
        }
    }

}

