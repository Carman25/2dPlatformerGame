using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    private int sign;
    void Start()
    {
        sign = -1; 
        changeSign();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + 0.0005f * sign, transform.position.y);   
    }
    void changeSign(){
        sign = -sign;
        Invoke("changeSign", 1.5f);
    }
}
