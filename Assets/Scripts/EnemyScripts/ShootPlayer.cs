using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public float speed;
    public float minimumDistance;
    public float shotDelay;

    public Transform target;

    public GameObject projectile;

    float shotTime;

    void Update(){
        if (Time.time > shotTime){
            GameObject projectileClone = Instantiate(projectile, projectile.transform.position, Quaternion.identity);
            projectileClone.SetActive(true);

            shotTime = Time.time + shotDelay;
        }

        if (Vector2.Distance(transform.position, target.position) < minimumDistance){
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        
    }
}
