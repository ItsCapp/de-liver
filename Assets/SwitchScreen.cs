using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class SwitchScreen : MonoBehaviour
{
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
      SceneManager.LoadScene("Shop");  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
