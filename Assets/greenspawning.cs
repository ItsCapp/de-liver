using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class greenspawning : MonoBehaviour
{
    public Transform cameratransform;
    public GameObject enemy;

    public float timer = 5;
    [SerializeField] float timercounter;

    // Start is called before the first frame update
    void Start()
    {
        timercounter = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timercounter -= Time.deltaTime;

        if (timercounter <= 0)
        {
            timercounter = timer + Random.Range(timer, 5);

            Instantiate(enemy, cameratransform.position + new Vector3(50,Random.Range(0, 50),0), transform.rotation);
        }
    }
}
