using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // MainMenuCanv mainMenuCanv = new MainMenuCanv();
    public bool[] levelEnableTracker;
    private static bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!initialized) {
            initialized = true;
            print("bruh moment");
        }
        levelEnableTracker = new bool[4];
        levelEnableTracker[0] = true;
        levelEnableTracker[1] = true;
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadScene(int sceneIndex) {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    //, MainMenuCanv mainMenuCanv
    public void LoadSceneIfUnlocked(int sceneIndex) {
        if(getLevelAvailability(sceneIndex)) {
            // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }   
    }

    // TODO: Bug fix, doesn't undo the pause menu or remove the button when scene respawned
    public void reloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMenuScene() {
        SceneManager.LoadScene(0);
    }
     public void setLevelAvailability(int index, bool available) {
        levelEnableTracker[index] = available;
    }

    public bool getLevelAvailability(int index) {
        return levelEnableTracker[index];
    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
