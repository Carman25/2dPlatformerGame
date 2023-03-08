using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagCon : MonoBehaviour
{
    private GameObject Player;
    public GameObject EndFlag;
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
        SceneManager.LoadScene(2);
    }

    public void TeleportPlayer(){
        Player.transform.position = EndFlag.transform.position;
        CameraOn.enabled = true;
        CameraOff.enabled = false;
    }
}
