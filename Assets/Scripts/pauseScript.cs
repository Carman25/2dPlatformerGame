using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !isPaused){
            Time.timeScale = 0;
            isPaused = !isPaused;
        }else if(Input.GetKeyDown(KeyCode.P) && isPaused){
            Time.timeScale = 1;
            isPaused = !isPaused;
        }
    }
}
