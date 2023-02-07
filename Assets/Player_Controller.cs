using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //Rigidbody of Player (not Hitbox) is preventing upward movement by slimes, not sure why
    //Tried changing kinematic rigidbody, didn't change, tried changing layer matrix, didn't work

    //invicibility frames isnt working, maybe delay between communication between Enemy OnCollision and player.Heallth?


    public float health = 10;
    public float maxHealth = 10;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    // public swordAttack swordAttack;
    public bool isDead = false;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    bool canMove = true;
    // public bool canTakeDamage = true;
    // public float frames;
    // public float invFrames = 1;


    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void FixedUpdate() {
        // frames++;
        // print(frames);
        // if(frames >= invFrames){
        //     canTakeDamage = true;
        // }

        if(canMove && isDead == false){
            if(movementInput != Vector2.zero){
                bool success = TryMove(movementInput);

                if(!success && movementInput.x > 0){
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if(!success){
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }

                animator.SetBool("isMoving", success);
            }else{
                animator.SetBool("isMoving", false);
            }

            //set direction of sprite to movement direction
            if(movementInput.x < 0){
                spriteRenderer.flipX = true;
            }else if(movementInput.x > 0){
                spriteRenderer.flipX = false;
            }
        }
        
    }

        private bool TryMove(Vector2 direction){
            if(direction != Vector2.zero){
               
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if(count == 0){
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }else{
                return false;   
            }
        }else{
            return false;
        }
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        
    }



    public void LockMovement(){
        canMove = false;
    }
    public void UnlockMovement(){
        canMove = true;
    }

    public float Health
    {
        set
        {
            health = value;
                
            if (health <= 0)
            {
                Dead();
            }
            
            
        }
        get
        {
            return health;
        }
    }

    public void Dead()
    {
        isDead = true;
        animator.SetBool("Dead", true);
    }

    public void RemovePlayer(){
        Destroy(gameObject);
    }

    public float getHealth()
    {
        float a = health / maxHealth;
        if (a >= 0){
            return (a);
        }else{
            return 0;
        }

    }

    // public void CoinCollected(){
    //     numCoins++;
    //     print("Coin Count: " + numCoins);
    // }

    public void Jump(){

    }


}

