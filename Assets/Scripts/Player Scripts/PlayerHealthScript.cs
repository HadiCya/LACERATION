using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int health;
    public int hitForce;

    public LayerMask enemyLayer;

    public PlayerMovement playerMovement;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "EnemyProjectile")
        {
            health -= 1;
        }
    }

    void setMoveMode()
    {
        playerMovement.moveMode = true;
    }
}
