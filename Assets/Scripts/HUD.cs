using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public float cooldownTime = 5f;
    public Image fillImage;
    public float fillSpeed = 0.5f;

    private float currentFillAmount = 0f;
    private float currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = cooldownTime;
        fillImage.fillAmount = 0f;
        Reset();

    }

    // Update is called once per frame
    void Update()
    {
        if (fillImage.fillAmount < 1)
        {
            // currentCooldown -= Time.deltaTime;
            currentFillAmount = Mathf.Clamp01(currentFillAmount + fillSpeed * Time.deltaTime);
            fillImage.fillAmount = currentFillAmount;
            

        }
    }

    public void Reset()
    {
        fillImage.fillAmount = 0f;
        // currentCooldown = cooldownTime;
        currentFillAmount = 0;
    }

}
