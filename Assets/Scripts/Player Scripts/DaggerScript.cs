using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    public int speed;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        transform.Translate(Vector3.up * speed *Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    /*void setDirection()
    {
        if (playerMovement.direction == "north")
        {
            transform.rotation = new Quaternion(0f, 0f, 0f);
        }
    }*/
}
