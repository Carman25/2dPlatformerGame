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
    private bool canMove, canDJ, isDashing, canDash;
    public bool dashUnlocked;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        // speed = 2f;
        // jp = 8f;
        animator = GetComponent<Animator>();
        canDJ = true;
        canDash = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDashing = false;
        rb = GetComponent<Rigidbody2D>();


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
        if(Input.GetButtonDown("Dash")){
            Dash();
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
        if(!isDashing){
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
        }

        

    }
    private bool isGrounded(){
        Vector2 size = new Vector2(0.05f, 0.1f);
        return Physics2D.OverlapBox(groundCheck.position, size, 0f, groundLayer);
    }

    private void Flip(float n){
        if(n < 0){
            spriteRenderer.flipX = true;
        }
        else if(n > 0){
            spriteRenderer.flipX = false;
        }
    }

    void Dash(){
        if(dashUnlocked && canDash){
            rb.gravityScale = 0;
        
            isDashing = true;
            animator.SetTrigger("Dash");
            canDash = false;
        }
        
    }

    void EndDash(){
        isDashing = false;
        rb.gravityScale = 1;
        Invoke("setCanDash", 2.25f);
    }

    void StartDashMove(){
        if(!spriteRenderer.flipX){
            rb.velocity = new Vector2(speed * 1.0f, 0);
        }else{
            rb.velocity = new Vector2(speed * -1.0f, 0);
        }

    }

    void StopDashMove(){
        rb.velocity = Vector2.zero;
    }

    void setCanDash(){
        canDash = true;
    }


}

