using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PC3 : MonoBehaviour
{
    //Rigidbody of Player (not Hitbox) is preventing upward movement by slimes, not sure why
    //Tried changing kinematic rigidbody, didn't change, tried changing layer matrix, didn't work

    //invicibility frames isnt working, maybe delay between communication between Enemy OnCollision and player.Heallth?


    public float health = 10;
    public float maxHealth = 10;
    
    public bool isDead = false;

   
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    bool canMove;
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
        canMove = true;
        
    }
    private void FixedUpdate() {
        // frames++;
        // print(frames);
        // if(frames >= invFrames){
        //     canTakeDamage = true;
        // }

       

            //set direction of sprite to movement direction
            
        
        
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
    

    
}
