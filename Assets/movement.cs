using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;

    public Animator animator;
    public SpriteRenderer sr;

    public GameObject arm1;
    public GameObject arm2;
    Vector2 arm1idleoffset = new Vector2(-1.2f, -1.025f);
    Vector2 arm2idleoffset = new Vector2(2f, -0.9f);
    Vector2 arm1runoffset = new Vector2(-0.4f, -0.75f);
    Vector2 arm2runoffset = new Vector2(2.6f, -0.6f);
    Vector2 arm1idleoffsetflipped = new Vector2(1f, -0.9f);
    Vector2 arm2idleoffsetflipped = new Vector2(-2f, -0.9f);
    Vector2 arm1runoffsetflipped = new Vector2(0.4f, -0.7f);
    Vector2 arm2runoffsetflipped = new Vector2(-2.7f, -0.7f);
    public SpriteRenderer arm1renderer;
    public SpriteRenderer arm2renderer;

    [SerializeField] private LayerMask platformLayerMask;
    float extraHeight = 0.1f;
    public bool grounded = false;
    float coyotetime = 0.1f;
    [SerializeField] float coyotetimecounter;
    bool jumping;
    float jumpCooldown = 0.2f;
    float jumpCooldownCounter;

    public int maxhealth = 3;
    public int health;
    public bool dead = false;
    public float hitstun = 0.01f;
    [SerializeField] float hitstuncounter;
    public GameObject cam;

    string currentanim = "idle";

    [SerializeField] float speed = 10;
    [SerializeField] float jumpforce = 10;
    [SerializeField] float gravity = 5;
    [SerializeField] float maxspeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();

        rb.gravityScale = gravity;

        health = maxhealth;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);

        return raycastHit.collider != null;
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log(rb.position.y);
        if (rb.position.y < -130){
            health = 0;
        }
        if (health <= 0)
        {
            Time.timeScale = 0;
            dead = true;
        }

        if (!dead)
        {
            if (hitstuncounter < 0)
            {
                Time.timeScale = 1;
                cam.transform.rotation = Quaternion.identity;
                cam.GetComponent<Camera>().orthographicSize = 5;
            }
            else
            {
                hitstuncounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true && coyotetimecounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
            coyotetimecounter = 0f;
            grounded = false;
            jumping = true;
            jumpCooldownCounter = jumpCooldown;
        }

        if (!jumping)
        {
            if (IsGrounded())
            {
                coyotetimecounter = coyotetime;
            }
            else
            {
                coyotetimecounter -= Time.deltaTime;
            }

            if (coyotetimecounter > 0)
            {
                grounded = true;
            }
            else if (coyotetimecounter <= 0)
            {
                grounded = false;
            }
        }
        else
        {
            jumpCooldownCounter -= Time.deltaTime;
        }

        if (jumpCooldownCounter <= 0)
        {
            jumping = false;
        }
        else
        {
            jumping = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed, ForceMode2D.Impulse);
            sr.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
            sr.flipX = false;
        }
        else
        {
            if (grounded)
            {
                if (rb.velocity.x > 1)
                {
                    rb.velocity = new Vector2(rb.velocity.x - 1f, rb.velocity.y);
                }
                else if (rb.velocity.x < -1)
                {
                    rb.velocity = new Vector2(rb.velocity.x + 1f, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
        }

        if (rb.velocity.magnitude > 0.5)
        {
            if (currentanim != "run")
            {
                animator.Play("run");
                currentanim = "run";
            }
            else if (currentanim == "run")
            { 
                if (sr.flipX == false)
                {
                    arm1renderer.flipX = false;
                    arm1.transform.localPosition = arm1runoffset;

                    arm2renderer.flipX = false;
                    arm2.transform.localPosition = arm2runoffset;
                }
                else
                {
                    arm1renderer.flipX = true;
                    arm1.transform.localPosition = arm1runoffsetflipped;

                    arm2renderer.flipX = true;
                    arm2.transform.localPosition = arm2runoffsetflipped;
                }
            }
        }
        else if (rb.velocity.magnitude <= 0.5)
        {
            if (currentanim != "idle")
            {
                animator.Play("idle");
                currentanim = "idle";

            }
            else if (currentanim == "idle")
            {
                if (sr.flipX == false)
                {
                    arm1renderer.flipX = false;
                    arm1.transform.localPosition = arm1idleoffset;

                    arm2renderer.flipX = false;
                    arm2.transform.localPosition = arm2idleoffset;
                }
                else
                {
                    arm1renderer.flipX = true;
                    arm1.transform.localPosition = arm1idleoffsetflipped;

                    arm2renderer.flipX = true;
                    arm2.transform.localPosition = arm2idleoffsetflipped;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("took damage");

            hitstuncounter = hitstun;

            cam.transform.Rotate(0, 0, Random.Range(-20, 20));
            cam.GetComponent<Camera>().orthographicSize = 4.5f;

            health -= 1;

            Time.timeScale = 0.01f;
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxspeed)
        {
            var vel = rb.velocity;
            var clamped = Vector2.ClampMagnitude(vel, maxspeed);
            clamped.y = vel.y;
            rb.velocity = clamped;
        }
    }
}