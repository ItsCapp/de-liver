using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject meleeattack;
    public GameObject bullet;

    float attackcooldown = 0.1f;
    float attackcooldowncounter;

    float meleeattackcooldown = 0.3f;
    float meleeattackcooldowncounter;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackcooldowncounter <= 0 && meleeattackcooldowncounter <= 0) //regular attack
        {
            Debug.Log("attack");
            attackcooldowncounter = attackcooldown;

            Instantiate(bullet, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && meleeattackcooldowncounter <= 0 && attackcooldowncounter <= 0) //melee attack
        {
            Debug.Log("meleeattack");
            meleeattackcooldowncounter = meleeattackcooldown;

            Instantiate(meleeattack, transform.position, transform.rotation);
        }

        meleeattackcooldowncounter -= Time.deltaTime;
        attackcooldowncounter -= Time.deltaTime;
    }
}
