using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanv : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = 0.2f * Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0){
            transform.position = new Vector2(transform.position.x, transform.position.y - scroll); 
        }
    }

}
