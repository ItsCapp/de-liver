using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class SetOrganMoney : MonoBehaviour
{
    float timer=0;
    public TMP_Text buttonText;
   public static int organMoney;
    // Start is called before the first frame update
    void Start()
    {
        organMoney = GlobalVars.organHeartNum*50 + GlobalVars.organKindneyNum*25 + GlobalVars.organLiverNum*10;

    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
       
        buttonText.text= "Sell Organs for \n$" + organMoney ;
    }
    
}
