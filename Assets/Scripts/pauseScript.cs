using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    private bool isPaused;
    // public GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        // GameObject.Find("PauseMenu").SetActive(true);
        // GameObject.Find("PausePanel").GetComponent<Image>();
        // Image.SetActive(true);
        GameObject.Find("PausePanel").GetComponent<CanvasRenderer>().SetAlpha(0);

        // GameObject.Find("Restart Level").SetActive(false);
        GameObject.Find("RestartLevel").GetComponent<CanvasRenderer>().SetAlpha(0);
        GameObject.Find("RestartText").GetComponent<CanvasRenderer>().SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !isPaused){
            Time.timeScale = 0;
            isPaused = !isPaused;
            GameObject.Find("PausePanel").GetComponent<CanvasRenderer>().SetAlpha(1);
            // setActive(true);
            // GameObject.Find("Restart Level").SetActive(true);
            GameObject.Find("RestartLevel").GetComponent<CanvasRenderer>().SetAlpha(1);
            GameObject.Find("RestartText").GetComponent<CanvasRenderer>().SetAlpha(1);
        }
        else if(Input.GetKeyDown(KeyCode.P) && isPaused){
            Time.timeScale = 1;
            isPaused = !isPaused;
            GameObject.Find("PausePanel").GetComponent<CanvasRenderer>().SetAlpha(0);
            // setActive(false);
            // GameObject.Find("Restart Level").SetActive(false);
            GameObject.Find("RestartLevel").GetComponent<CanvasRenderer>().SetAlpha(0);
            GameObject.Find("RestartText").GetComponent<CanvasRenderer>().SetAlpha(0);
        }
    }
}
