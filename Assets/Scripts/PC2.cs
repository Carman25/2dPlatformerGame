using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PC2 : MonoBehaviour
{
    private float horizontal, movingPlatformXSpeed, movingPlatformYSpeed;
    public float speed, JumpPower, startTime, maxDistance;
    SpriteRenderer spriteRenderer;
    Animator animator;
    private bool canDoubleJump, isDashing, isStart, isOnMovingPlatform;
    public bool canDash, devMode;
    public Vector3 boxSize;
    private HUD dashHud;
    private static bool hardMode;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        if(devMode){
            hardMode = false;
            canDoubleJump = true;
            startTime = 0;  
        }
        if(hardMode){
            JumpPower = 4.0f;
        }else{
            JumpPower = 4.1f;
        }
        movingPlatformXSpeed = 0;
        animator = GetComponent<Animator>();
        canDoubleJump = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDashing = false;
        rb = GetComponent<Rigidbody2D>();
        isStart = true;
        isOnMovingPlatform = false;
        canDash = true;
        Invoke("setIsStart", startTime);
        if(GameObject.FindGameObjectWithTag("DashHud") != null){
            dashHud = GameObject.FindGameObjectWithTag("DashHud").GetComponent<HUD>();
        }
    }

    void Update(){
        // bool hi = JumpRing2.getDJ();
        if(!isStart || devMode){
            horizontal = Input.GetAxisRaw("Horizontal");

            if(Input.GetButtonDown("Jump") && !isDashing){
                if(isGrounded() || devMode){
                    rb.velocity = new Vector2(rb.velocity.x, JumpPower);
                    animator.SetTrigger("Jump");
                    isOnMovingPlatform = false;
                    // isGrounded = false;
                }
                else if(canDoubleJump){
                    rb.velocity = new Vector2(rb.velocity.x, JumpPower * 0.8f);
                    canDoubleJump = false;
                    animator.SetTrigger("Jump");
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
                if(horizontal != 0){
                    animator.SetBool("isMoving", true);
                    Flip(horizontal);
                }
                else{
                    animator.SetBool("isMoving", false);
                }
                if(isGrounded() == false){
                    rb.velocity = new Vector2(horizontal * speed * 0.7f, rb.velocity.y); 
                    animator.SetBool("isMoving", false);
                    // Flip(horizontal);
                }
                else{
                    
                    if (isOnMovingPlatform) {
                        // && (rb.velocity.y == movingPlatformYSpeed || rb.velocity.y == -movingPlatformYSpeed)
                        //!Input.GetButtonDown("Jump")
                        rb.velocity = new Vector2(horizontal * speed + movingPlatformXSpeed, movingPlatformYSpeed);
                    }
                    // else if(!isOnMovingPlatform)
                    else{
                        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                    }
                }
                // else{
                //     rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                // }                       
            }
        }
        if(isGrounded() || isOnMovingPlatform){
            animator.SetBool("isGrounded", true);
        }else{
            animator.SetBool("isGrounded", false);
        }

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
            if(!isGrounded() && !isOnMovingPlatform){
                animator.SetTrigger("Dash");
                if(dashHud != null){
                    dashHud.Reset();
                }
                if(!devMode){
                    canDash = false;
                }
            } 
        }
    }
    public void OnCollisionStay2D(Collision2D other){
        if(isGrounded() && other.gameObject.CompareTag("MovingTiles")){
            StageMovement sm = other.gameObject.GetComponent<StageMovement>();
            if(sm != null){
                if(!sm.isSticky() && !sm.isBouncy()) {
                    movingPlatformYSpeed = rb.velocity.y;
                    // rb.velocity = new Vector2(sm.platformXVel() + rb.velocity.x, rb.velocity.y);
                }
                else if (sm.isSticky()) {
                    movingPlatformYSpeed = sm.platformYVel();
                    // rb.velocity = new Vector2(sm.platformXVel() + rb.velocity.x, sm.platformYVel());
                }
                else if (sm.isBouncy()) {
                    movingPlatformYSpeed = sm.platformYVel() + rb.velocity.y;
                    // rb.velocity = new Vector2(sm.platformXVel() + rb.velocity.x, sm.platformYVel()  + rb.velocity.y);
                }
                else {
                    movingPlatformYSpeed = rb.velocity.y;
                }
                movingPlatformXSpeed = sm.platformXVel();
            }
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
            // movingPlatformXSpeed = 0;
            // movingPlatformYSpeed = 0;
        }
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawCube(groundCheck.transform.position, boxSize);
    }
    void setIsStart(){
        isStart = false;
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

    
    void EndDash(){
        isDashing = false;
        rb.gravityScale = 1;
        Invoke("setCanDash", 2.25f);
    }

    public bool getDash(){
        return canDash;
    }

    public void setDash(bool dash){
        canDash = dash;
    }

    public void OutsideJump(){
        rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        animator.SetTrigger("Jump");
    }

    public void setHardMode(){
        hardMode = true;
        print("hardMode is set to " + hardMode);
    }

    public void setEasyMode(){
        hardMode = false;
        print("hardMode is set to " + hardMode);
    }
}
