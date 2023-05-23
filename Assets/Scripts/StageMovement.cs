using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    private int sign;
    public float speed, speed2, moveTime;
    public bool stickyPlatform, bouncyPlatform;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, speed2);
        sign = -1;
        changeSign(); 
    }

    // Update is called once per frame
    void Update()
    {
    }
    void changeSign(){
        sign = -sign;
        Invoke("changeSign", moveTime);
        updateSpeed();
    }

    public float platformXVel(){
        return speed * sign;
    }
    public float platformYVel(){
        return speed2 * sign;
    }

    void updateSpeed() {
        rb.velocity = new Vector2(speed * sign, speed2 * sign);
    }

    public bool isSticky() {
        return stickyPlatform;
    }
    public bool isBouncy() {
        return bouncyPlatform;
    }
}
