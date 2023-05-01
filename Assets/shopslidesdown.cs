using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopslidesdown : MonoBehaviour
{
    float time;
    float t;
    public float ScrollTime;

    // Start is called before the first frame update
    void Start()
    {
        time = t = 0;
    }

    // Update is called once per frame
    void Update()
    {  var Maincam = Camera.main;
        if (time < ScrollTime)
        {
            time += Time.deltaTime;
            t = Mathf.Sin((time/ScrollTime) * Mathf.PI * 0.5f);
      
            Maincam.transform.position = new Vector3(0, Mathf.Lerp(16,0,Mathf.Min(t, 1)), -100);
        }
        else{
                Maincam.transform.position = new Vector3(0,0, -100);
        }
      Debug.Log(t);
    }
}
