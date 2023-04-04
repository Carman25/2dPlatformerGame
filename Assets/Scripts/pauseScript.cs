using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    private bool isPaused, mouseVisible;
    // public GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        mouseVisible = false;
        // GameObject.Find("PauseMenu").SetActive(true);
        // GameObject.Find("PausePanel").GetComponent<Image>();
        // Image.SetActive(true);
        // GameObject.Find("Restart Level").SetActive(false);
        setComponentsVisible(0);
        cursorSetVisible(mouseVisible);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            mouseVisible = !mouseVisible;
            cursorSetVisible(mouseVisible);
        }
        if(Input.GetKeyDown(KeyCode.P) && !isPaused){
            Time.timeScale = 0;
            isPaused = !isPaused;
            setComponentsVisible(1);
            cursorSetVisible(true);
        }
        else if(Input.GetKeyDown(KeyCode.P) && isPaused){
            Time.timeScale = 1;
            isPaused = !isPaused;
            setComponentsVisible(0);
            cursorSetVisible(false);
        }
    }

    public void setComponentsVisible(int setState) {
        GameObject.Find("PausePanel").GetComponent<CanvasRenderer>().SetAlpha(setState);
        // setActive(true);
        // GameObject.Find("Restart Level").SetActive(true);
        GameObject.Find("RestartLevel").GetComponent<CanvasRenderer>().SetAlpha(setState);
        GameObject.Find("RestartText").GetComponent<CanvasRenderer>().SetAlpha(setState);
        GameObject.Find("ReturnToMenu").GetComponent<CanvasRenderer>().SetAlpha(setState);
        GameObject.Find("MainMenuText").GetComponent<CanvasRenderer>().SetAlpha(setState);
    }

    public void timeScaleSet(int setState) {
        Time.timeScale = setState;
    }

    public void cursorSetVisible(bool set) {
        if(set) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }  
    }
}
