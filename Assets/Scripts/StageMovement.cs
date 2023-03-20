using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    private int sign;
    public float speed, speed2, moveTime;
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
        rb.velocity = new Vector2(speed * sign, speed2 * sign);
    }
    void changeSign(){
        sign = -sign;
        Invoke("changeSign", moveTime);
    }

    public float platformVel(){
        return speed * sign;
    }
}
