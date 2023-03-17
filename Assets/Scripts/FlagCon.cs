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
        updateSceneAvailability(true);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void TeleportPlayer(){
        Player.transform.position = EndFlag.transform.position;
        if(CameraOn != null && CameraOff != null){
            CameraOn.enabled = true;
            CameraOff.enabled = false;
        }
    }

    public void updateSceneAvailability(bool available) {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameObject.Find("SceneLoader").GetComponent<SceneLoader>().setLevelAvailability(currentSceneIndex, available);
    }
}
