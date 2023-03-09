using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{


    private PC2 playerController;
    private Animator animator;

    // Start is called before the first frame update
    void Start(){
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PC2>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openChest(){
        playerController.setDash(true);
        animator.SetBool("OpenChest", true);
    }
}
