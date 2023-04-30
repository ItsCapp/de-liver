using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonHandler : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("level", LoadSceneMode.Single);
    }

    public void shop()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }

    public void menu()
    {
        Debug.Log("no menu yet!");
    }
}
