using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRing2 : MonoBehaviour
{
    private GameObject Player;
    public float JumpPower;
    public bool canDJ;
    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        canDJ = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D CollisionCheck)
     {
         if (CollisionCheck.gameObject.tag == "Player") 
             {
             canDJ = true;
               } 
     }

    public bool getDJ(){
        return canDJ;
    }

    public void jumping(){
        if(canDJ = true){
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            animator.SetTrigger("Jump");
        }
    }
}
