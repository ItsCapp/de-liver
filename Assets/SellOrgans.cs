using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellOrgans : MonoBehaviour
{
    // Start is called before the first frame update
     // Use this for initialization
     public Button butt;
     void Start () {
     butt.onClick.AddListener(() => {Bingoid();});
     }
     
     // Update is called once per frame
     void Update () {
     
     }

    public void Bingoid () {  
        GlobalVars.coins +=SetOrganMoney.organMoney;
        SetOrganMoney.organMoney = 0;

     }
}
