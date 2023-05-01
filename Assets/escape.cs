using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class escape : MonoBehaviour
{
    public AudioSource escapemusic;

    public GameObject getouttext;
    public GameObject timertext;

    public bool escaping = false;

    public TMP_Text text;
    int timer = 90;
    float timercount;

    public movement movscript;

    private void Start()
    {
        timertext.SetActive(false);
        getouttext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (escaping)
        {
            if (!escapemusic.isPlaying)
            {
                escapemusic.Play();

                getouttext.SetActive(true);
                timertext.SetActive(true);
            }

            if (timer - (int)timercount == 0)
            {
                movscript.health = 0;
            }

            timercount += Time.deltaTime;
        }

        text.text = "time remaining: " + (timer - (int)timercount) + " seconds";
    }
}
