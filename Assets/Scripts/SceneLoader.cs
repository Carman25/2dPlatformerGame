using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // MainMenuCanv mainMenuCanv = new MainMenuCanv();
    public static bool[] levelEnableTracker;
    // private static bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        // if(!initialized) {
        //     initialized = true;
        // print("bruh moment");
        levelEnableTracker = new bool[5];
        levelEnableTracker[0] = true;
        levelEnableTracker[1] = true;
        // foreach (bool item in levelEnableTracker){
        //     print(item);
        // }
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadScene(int sceneIndex) {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void unlockAndLoadScene(int sceneIndex) {
        setLevelAvailability(sceneIndex, true);
        LoadSceneIfUnlocked(sceneIndex);
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
        print("Set Level " + index + " available");
    }

    public bool getLevelAvailability(int index) {
        return levelEnableTracker[index];
    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
