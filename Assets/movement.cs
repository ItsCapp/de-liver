using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CircleCollider2D col;

    public Animator animator;
    public SpriteRenderer sr;

    public escape escape;

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

    public randomizationorgan ro;

    [SerializeField] private LayerMask platformLayerMask;
    float extraHeight = 0.1f;
    public bool grounded = false;
    float coyotetime = 0.1f;
    [SerializeField] float coyotetimecounter;
    bool jumping;
    float jumpCooldown = 0.2f;
    float jumpCooldownCounter;

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
     Vector3 respawn;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();

        rb.gravityScale = gravity;

        health = GlobalVars.heartNum;
        speed += GlobalVars.speedLvl * 2;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);

        return raycastHit.collider != null;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.y < -130)
        {
            health = 0;
        }

        if (health <= 0)
        {
            Time.timeScale = 1;
            if (GlobalVars.lifeupNum < 1){
            dead = true;
            SceneManager.LoadScene("restartscreen", LoadSceneMode.Single);
            }
            else {
                GlobalVars.lifeupNum -= 1;
                health = GlobalVars.heartNum;
                transform.position = respawn;
                 rb.velocity = new Vector2(0,0);
            }
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
                respawn.x = transform.position.x;
                respawn.y = transform.position.y;
                respawn.y = transform.position.z;

                Debug.Log(transform.position);
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

    private void Awake()
    {
        ro = GameObject.FindObjectOfType<randomizationorgan>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("took damage");

            hitstuncounter = hitstun;

            int randomangle = 0;
            randomangle = Random.Range(1, 3);

            if (randomangle == 1)
            {
                randomangle = -10;
            }
            else if (randomangle == 2)
            {
                randomangle = 10;
            }

            cam.transform.Rotate(0, 0, randomangle);
            Debug.Log(cam.transform.rotation);
            cam.GetComponent<Camera>().orthographicSize = 4.5f;

            health -= 1;

            Time.timeScale = 0.01f;
        }

        if (collision.gameObject.tag == "organ")
        {
            if (ro.organ == "liver")
            {
                GlobalVars.organLiverNum += 1;
                Debug.Log("liver");
            }
            else if (ro.organ == "kidney")
            {
                GlobalVars.organKindneyNum += 1;
                Debug.Log("kidney");
            }
            else
            {
                GlobalVars.organHeartNum += 1;
                Debug.Log("heart");
            }

            Destroy(collision.gameObject);
            escape.escaping = true;
        }

        if (collision.gameObject.tag == "escape")
        {
            SceneManager.LoadScene("Shop", LoadSceneMode.Single);
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