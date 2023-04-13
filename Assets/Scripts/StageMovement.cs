using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    private int sign;
    public float xVel, yVel, moveTime, conveyorSpeed;
    private Rigidbody2D rb;
    void Start()
    {
        sign = -1;
        changeSign();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xVel * sign, yVel * sign);
    }
    void changeSign(){
        sign = -sign;
        Invoke("changeSign", moveTime);
    }

    public float platformXVel(){
        return xVel * sign;
    }

    public float conSpeed(){
        return conveyorSpeed;
    }
}
