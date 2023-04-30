using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeattack : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    movement m;

    private float killtimer = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        m = player.GetComponent<movement>();

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    private void Update()
    {
        transform.position = player.transform.position;

        killtimer -= Time.deltaTime;

        if (killtimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bouncable")
        {
            if (m.grounded == false)
            {
                var magnitude = 25;

                var force = player.transform.position - collision.transform.position;

                force.Normalize();

                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(force * magnitude, ForceMode2D.Impulse);
            }
        }
        else if (collision.tag == "enemy")
        {
            Debug.Log("collided with enemy");

            enemygreen script = collision.GetComponent<enemygreen>();

            script.health -= 5;

            if (m.grounded == false)
            {
                var magnitude = 20;

                var force = player.transform.position - collision.transform.position;

                force.Normalize();

                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(force * magnitude, ForceMode2D.Impulse);
            }
        }
    }
}
