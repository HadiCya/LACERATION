using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;

    public GameObject projectile;
    public float shotDelay;
    float shotTime;

    void Update(){
        if (Time.time > shotTime){
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotTime = Time.time + shotDelay;
        }

        if (Vector2.Distance(transform.position, target.position) < minimumDistance){
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        
    }
}
