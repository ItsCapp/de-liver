using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygreen : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playertransform;

    public float health = 10;

    public float smoothSpeed;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPos = playertransform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertransform = player.GetComponent<Transform>();

        smoothSpeed = Random.Range(0.001f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
