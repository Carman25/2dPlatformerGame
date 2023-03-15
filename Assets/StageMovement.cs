using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    private int sign;
    public float speed;
    private Rigidbody2D rb;
    void Start()
    {
        sign = -1; 
        changeSign();
        rb = GetComponent<Rigidbody2D>();
        speed = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * sign, 0);
    }
    void changeSign(){
        sign = -sign;
        Invoke("changeSign", 1.5f);
    }

    public float platformVel(){
        return speed * sign;
    }
}
