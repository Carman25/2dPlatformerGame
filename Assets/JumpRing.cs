using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRing : MonoBehaviour
{
    private GameObject Player;
    public float JumpPower;
    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void jumping(){
        rb.velocity = new Vector2(rb.velocity.x, JumpPower);
                    animator.SetTrigger("Jump");
    }
}
