using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PC2 : MonoBehaviour
{
    private float horizontal, movingPlatformSpeed;
    public float speed, JumpPower, startTime, maxDistance;
    SpriteRenderer spriteRenderer;
    Animator animator;
    private bool canDoubleJump, isDashing, isStart, isOnMovingPlatform;
    public bool canDash, hardMode, devMode;
    public Vector3 boxSize;
    private HUD dashHud;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        if(devMode){
            canDash = true;
            hardMode = false;
            canDoubleJump = true;
            startTime = 0;  
        }


        if(hardMode){
            JumpPower = 4.0f;
        }else{
            JumpPower = 4.1f;
        }
        movingPlatformSpeed = 0;
        animator = GetComponent<Animator>();
        canDoubleJump = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDashing = false;
        rb = GetComponent<Rigidbody2D>();
        isStart = true;
        isOnMovingPlatform = false;
        Invoke("setIsStart", startTime);
        dashHud = GameObject.FindGameObjectWithTag("DashHud").GetComponent<HUD>();

    }

    void Update(){
        // bool hi = JumpRing2.getDJ();
        if(!isStart || devMode){
            horizontal = Input.GetAxisRaw("Horizontal");

            if(Input.GetButtonDown("Jump") && !isDashing){
                if(isGrounded() || devMode){
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
            if(isGrounded()){
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
                    if(horizontal != 0){
                            animator.SetBool("isMoving", true);
                            Flip(horizontal);
                        }
                    else{
                            animator.SetBool("isMoving", false);
                    } 
                    if(isOnMovingPlatform){
                        rb.velocity = new Vector2(horizontal * speed + movingPlatformSpeed, rb.velocity.y);
                    }else{
                        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                    }
                }
            }

        }
        if(isGrounded() || isOnMovingPlatform){
            animator.SetBool("isGrounded", true);
        }else{
            animator.SetBool("isGrounded", false);
        }

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
        if(canDash && !isDashing){
            animator.SetTrigger("Dash");
            dashHud.Reset();
            canDash = false;
        }
    }

    void EndDash(){
        isDashing = false;
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
    public void OnCollisionStay2D(Collision2D other){
        if(isGrounded() && other.gameObject.CompareTag("MovingTiles")){
            StageMovement sm = other.gameObject.GetComponent<StageMovement>();
            if(sm != null){
                rb.velocity = new Vector2(sm.platformVel() + rb.velocity.x, rb.velocity.y);
            }
            movingPlatformSpeed = sm.platformVel();
        }

    }

    public void OnCollisionEnter2D(Collision2D other){
        if(isGrounded() && other.gameObject.CompareTag("MovingTiles")){
            isOnMovingPlatform = true;
            
            

        }
    }

    public void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("MovingTiles")){
            isOnMovingPlatform = false;
            movingPlatformSpeed = 0;
        }
        
    }

    public void OutsideJump(){
        rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        animator.SetTrigger("Jump");
    }
}
