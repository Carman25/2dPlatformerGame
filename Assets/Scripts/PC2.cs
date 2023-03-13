using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PC2 : MonoBehaviour
{
    private float horizontal;
    public float speed, JumpPower, startTime, maxDistance;
    SpriteRenderer spriteRenderer;
    Animator animator;
    private bool canMove, canDoubleJump, isDashing, usedDash, isStart;
    public bool canDash, hardMode, devMode;
    public Vector3 boxSize;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        if(devMode){
            canDash = true;
            hardMode = false;
            canDoubleJump = true;
            canMove = true;
            startTime = 0;  
        }


        if(hardMode){
            JumpPower = 4.0f;
        }else{
            JumpPower = 4.1f;
        }
        animator = GetComponent<Animator>();
        canDoubleJump = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDashing = false;
        usedDash = false;
        rb = GetComponent<Rigidbody2D>();
        isStart = true;
        Invoke("setIsStart", startTime);

    }

    void Update(){
        if(!isStart || devMode){
            horizontal = Input.GetAxisRaw("Horizontal");

            if(Input.GetButtonDown("Jump") && !isDashing){
                if(isGrounded()){
                    rb.velocity = new Vector2(rb.velocity.x, JumpPower);
                    animator.SetTrigger("Jump");
                    
                }
                else if(canDoubleJump){
                    rb.velocity = new Vector2(rb.velocity.x, JumpPower * 0.8f);
                    canDoubleJump = false;
                    animator.SetTrigger("Jump");
                }
                else{
                    
                }
                
                
            }
            if(Input.GetButtonDown("Dash")){
                Dash();
            }
            if(isGrounded() || devMode){
                canDoubleJump = true;
            }
        }
    }
    void FixedUpdate(){
        if(!isStart || devMode){
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

            //turns dash back on once grounded
            if(isGrounded() == true || devMode){
                usedDash = false;
            }
        }
        animator.SetBool("isGrounded", isGrounded());
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawCube(groundCheck.transform.position, boxSize);
    }

    private bool isGrounded(){
        if(Physics2D.BoxCast(groundCheck.transform.position, boxSize, 0, -groundCheck.transform.up, maxDistance, groundLayer))
        {
            return true;
            
        }
        else
        {
            return false;
        }
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
        if(canDash && !isDashing && !usedDash){
            animator.SetTrigger("Dash");
        }
    }

    void EndDash(){
        isDashing = false;
        usedDash = true;
        rb.gravityScale = 1;
        Invoke("setCanDash", 2.25f);
    }

    void StartDashMove(){
        rb.gravityScale = 0;

        if(!spriteRenderer.flipX){
            rb.velocity = new Vector2(speed * 1.0f, 0);
        }else{
            rb.velocity = new Vector2(speed * -1.0f, 0);
        }
        isDashing = true;

    }

    void StopDashMove(){
        rb.velocity = Vector2.zero;
    }

    private void setCanDash(){
        canDash = true;
    }

    void setIsStart(){
        isStart = false;
    }

    public bool getDash(){
        return canDash;
    }

    public void setDash(bool dash){
        canDash = dash;
    }
}

