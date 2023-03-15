using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextThing : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string text1, text2, text3, text4, text5, text6, text7;
    private string[] words;
    private int ling;
    public int numRounds;
    // Start is called before the first frame update
    void Start()
    {
        ling = 0;
        words = new string[7];
        words[0] = text1;
        words[1] = text2;
        words[2] = text3;
        words[3] = text4;
        words[4] = text5;
        words[5] = text6;
        words[6] = text7;
        for (int i = 0; i < numRounds; i++){
            float j = 2.5f * i;
            Invoke("changeText", j);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P)){

        }
    }

    void changeText(){
        text.text = words[ling];
        ling ++;
    }

    
}
