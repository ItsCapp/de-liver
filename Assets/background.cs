using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public Transform cam;
    public Vector3 backoffset;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = (-cam.position / 75) + backoffset;
    }
}
