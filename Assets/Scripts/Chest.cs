using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{


    private PC2 playerController;

    // Start is called before the first frame update
    void Start(){
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PC2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void openChest(){
        playerController.setDash(true);
    }
}
