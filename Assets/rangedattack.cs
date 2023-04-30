using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class rangedattack : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;

    Vector2 targetPos;

    private float killtimer = 5f;
    private float force = 15f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.velocity = new Vector2(targetPos.x, targetPos.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        killtimer -= Time.deltaTime;

        if (killtimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            enemygreen script = collision.GetComponent<enemygreen>();

            script.health -= 1;

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
