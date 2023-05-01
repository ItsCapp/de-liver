using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.UI;
public class UpdateCard : MonoBehaviour
{

    // 0 is heart
    // 1 is power
    //2 is speed
    // 3 is life ups

    // Start is called before the first frame update
        public TMP_Text amount;
        public TMP_Text value;
        public int cardID;
        public Button butt;
         int[] values ;
    void Start()
    {
        butt.onClick.AddListener(() => {Bingoid();});
         values = new int[] {7,5,5,99999};
         SetCardvalues();
    }

    // Update is called once per frame
    void SetCardvalues()
    {

    amount.text = "x";
        int val = 37;
        int num = 37;
        switch (cardID)
        {
        case 0:
            amount.text += GlobalVars.heartNum.ToString();
            num =  GlobalVars.heartNum;
            val = (GlobalVars.heartNum-1)*25;
        break;
        case 1:
             amount.text += GlobalVars.powerLvl.ToString();
                   num =   GlobalVars.powerLvl;
            val = (GlobalVars.powerLvl+1)*50;
        break;
        case 2:
            amount.text += GlobalVars.speedLvl.ToString();
                  num =  GlobalVars.speedLvl;
            val = (GlobalVars.speedLvl+1)*70;
        break;
        case 3:
            amount.text += GlobalVars.lifeupNum.ToString();
                  num = GlobalVars.lifeupNum;
            val = 150;
        break;
        }
        value.text = "$" + val.ToString();
        if (values[cardID] ==  num){
            value.text = "MAX";
        }
    }

    void Bingoid() {

switch (cardID)
        {
        case 0:
        if ((GlobalVars.coins >= (GlobalVars.heartNum-1)*25) && GlobalVars.heartNum < 8){
                GlobalVars.coins -=   (GlobalVars.heartNum-1)*25;
                GlobalVars.heartNum += 1;
            }
        break;
        case 1:
                if ((GlobalVars.coins >= (GlobalVars.powerLvl+1)*50) && GlobalVars.powerLvl < 6){
                GlobalVars.coins -=   (GlobalVars.powerLvl+1)*50;
                GlobalVars.powerLvl += 1;
            }
        break;
        case 2:
            if ((GlobalVars.coins >= (GlobalVars.speedLvl+1)*70) && GlobalVars.speedLvl < 6){
                GlobalVars.coins -=   (GlobalVars.speedLvl+1)*70;
                GlobalVars.speedLvl += 1;
            }
        break;
        case 3:
            if (GlobalVars.coins >= 150){
                GlobalVars.coins -=   150;
                GlobalVars.lifeupNum += 1;
            }
        break;
        }
        SetCardvalues();
    }

}
