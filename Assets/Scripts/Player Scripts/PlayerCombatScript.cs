using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{
    public int attackRange;
    public int chargeForce;

    public double energy = 0;

    public float cooldown;
    public float lastShot;

    public GameObject player;
    public GameObject meleeAttackPoint;
    public GameObject dagger;
    public GameObject firebreathObject;
    public GameObject acidObject;
    public GameObject shieldObject;
    public GameObject decoyObject;
    public GameObject minionObject;

    public LayerMask enemyLayers;

    public string currentPower = "none";

    public Rigidbody2D rb;

    public PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHandling();
        setPower();
    }

    void inputHandling()
    {
        if (Input.GetMouseButtonDown(0))
        {
            meleeAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            rangedAttack();
        }

        if(energy > 0)
        {
            if(currentPower == "firebreath")
            {
                if (Input.GetKey("q"))
                {
                    firebreath(true);
                    energy -= 0.05;
                }

                if (Input.GetKeyUp("q"))
                {
                    firebreath(false);
                }
            }

            if (currentPower == "acid")
            {
                if (Input.GetKeyDown("q"))
                {
                    acid();
                }
            }

            if (currentPower == "charge")
            {
                if (Input.GetKeyDown("q"))
                {
                    charge();
                }
            }

            if (currentPower == "shield")
            {
                if (Input.GetKey("q"))
                {
                    shield(true);
                    energy -= 0.05;
                }

                if (Input.GetKeyUp("q"))
                {
                    shield(false);
                }
            }

            if (currentPower == "decoy")
            {
                if (Input.GetKeyDown("q"))
                {
                    decoy();
                }
            }

            if (currentPower == "minion")
            {
                if (Input.GetKeyDown("q"))
                {
                    minion();
                }
            }

        }
        else
        {
            firebreath(false);
            shield(false);
        }
    }

    void meleeAttack()
    {
        Collider2D[] hitEnemeies = Physics2D.OverlapCircleAll(meleeAttackPoint.transform.position, attackRange, enemyLayers); //Collects all enemies within the range into an array

        foreach(Collider2D enemy in hitEnemeies)
        {
            Debug.Log(enemy.name);
        }
    }

    void rangedAttack()
    {
        GameObject daggerClone = Instantiate(dagger, dagger.transform.position, player.transform.rotation);
        daggerClone.SetActive(true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(meleeAttackPoint.transform.position, attackRange);
    }

    void setPower()
    {
        if(Input.GetKeyDown("1"))
        {
            currentPower = "firebreath";
            energy = 100;
        }

        if (Input.GetKeyDown("2"))
        {
            currentPower = "acid";
            energy = 100;
        }

        if (Input.GetKeyDown("3"))
        {
            currentPower = "charge";
            energy = 100;
        }

        if (Input.GetKeyDown("4"))
        {
            currentPower = "shield";
            energy = 100;
        }

        if (Input.GetKeyDown("5"))
        {
            currentPower = "decoy";
            energy = 100;
        }

        if (Input.GetKeyDown("6"))
        {
            currentPower = "minion";
            energy = 100;
        }
    }

    void firebreath(bool active)
    {
        firebreathObject.SetActive(active);
    }

    void acid()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;

        GameObject acidClone = Instantiate(acidObject, acidObject.transform.position, player.transform.rotation);
        acidClone.SetActive(true);
    }

    void charge()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;

        playerMovement.moveMode = false;
        rb.AddForce(transform.right * chargeForce * -1, ForceMode2D.Impulse);
        Invoke("setMoveMode", 1f);
    }

    void shield(bool active)
    {
        shieldObject.SetActive(active);
    }

    void decoy()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;

        GameObject decoyClone = Instantiate(decoyObject, acidObject.transform.position, player.transform.rotation);
        decoyObject.SetActive(true);
    }

    void minion()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;

        GameObject minionClone = Instantiate(minionObject, acidObject.transform.position, player.transform.rotation);
        minionObject.SetActive(true);
    }

    void setMoveMode()
    {
        playerMovement.moveMode = true;
    }
}