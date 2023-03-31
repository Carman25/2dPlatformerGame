using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagCon : MonoBehaviour
{
    private GameObject Player;
    public GameObject EndFlag;
    public int sceneToLoad;
    public Camera CameraOn, CameraOff;
    public bool SwitchesCamera;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void flagInteract(){

    }

    public void sceneChange() {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void finishLevel() {
        updateSceneAvailability(true, sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void TeleportPlayer(){
        Player.transform.position = EndFlag.transform.position;
            if(SwitchesCamera){
                CameraOn.enabled = true;
                CameraOff.enabled = false;
            }
            

    }

    public void updateSceneAvailability(bool available, int levelIndex) {
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameObject.Find("SceneLoader").GetComponent<SceneLoader>().setLevelAvailability(levelIndex, available);
    }
}
