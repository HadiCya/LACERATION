using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Vector3 playerPosition;
    public float speed;

    void Start(){
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        if (transform.position == playerPosition){
            Destroy(gameObject);
        }
    }
}
