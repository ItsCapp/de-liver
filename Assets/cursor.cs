using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    Transform t;

    Vector2 screenPos;
    public Vector2 worldPos;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = Input.mousePosition;

        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        t.position = new Vector3(worldPos.x, worldPos.y, -9);
    }
}
