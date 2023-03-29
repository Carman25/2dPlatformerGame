using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillController : MonoBehaviour
{
    public Image fillImage;
    public float fillAmount;

    // Start is called before the first frame update
    void Start()
    {
        fillImage.fillAmount = fillAmount;
    }

    // Update the fill amount
    public void UpdateFillAmount(float newAmount)
    {
        fillAmount = newAmount;
        fillImage.fillAmount = fillAmount;
    }
}