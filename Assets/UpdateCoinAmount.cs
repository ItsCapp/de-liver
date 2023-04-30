using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UpdateCoinAmount : MonoBehaviour
{
    float timer=0;
    public TMP_Text buttonText;
    static int organMoney;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
       
        buttonText.text= "$" + GlobalVars.coins.ToString() ;
    }
    
}
