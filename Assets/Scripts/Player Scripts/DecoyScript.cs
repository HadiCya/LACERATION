using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyScript : MonoBehaviour
{
    public int speed;
    
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
        transform.Translate(transform.up * speed * Time.deltaTime);
        transform.SetParent(null);
    }
}
