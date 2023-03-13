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
        GameObject.Find("PausePanel").GetComponent<CanvasRenderer>().SetAlpha(0);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !isPaused){
            Time.timeScale = 0;
            isPaused = !isPaused;
            GameObject.Find("PausePanel").GetComponent<CanvasRenderer>().SetAlpha(1);

        }else if(Input.GetKeyDown(KeyCode.P) && isPaused){
            Time.timeScale = 1;
            isPaused = !isPaused;
            GameObject.Find("PausePanel").GetComponent<CanvasRenderer>().SetAlpha(0);
        }
    }
}
