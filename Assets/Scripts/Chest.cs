using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{

    private PC2 playerController;
    private Animator animator;

    public Image dashOnCD, dashOffCd;
    private GameObject dt;

    // Start is called before the first frame update
    void Start(){
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PC2>();
        animator = GetComponent<Animator>();
        dt = GameObject.FindGameObjectWithTag("DashText");
        dt.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void openChest(){
        playerController.setDash(true);
        animator.SetBool("OpenChest", true);
        dashOnCD.enabled = true;
        dashOffCd.enabled = true;
        dt.SetActive(true);
    }

}
