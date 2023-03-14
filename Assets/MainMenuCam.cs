using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = 0.2f * Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0){
            transform.position = new Vector3(transform.position.x, transform.position.y + scroll, -10); 
        }
    }
}
