using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{
    public int attackRange;
    public double energy = 0;

    public GameObject player;
    public GameObject meleeAttackPoint;
    public GameObject dagger;
    public GameObject firebreathObject;

    public LayerMask enemyLayers;

    public string currentPower = "none";
    
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
        }
        else
        {
            firebreath(false);
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
        GameObject daggerClone = Instantiate(dagger, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);
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
    }

    void firebreath(bool active)
    {
        firebreathObject.SetActive(active);
    }
}
