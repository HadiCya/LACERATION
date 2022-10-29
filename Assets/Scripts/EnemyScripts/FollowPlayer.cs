using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;

    void Update(){
        if (Vector2.Distance(transform.position, target.position) > minimumDistance){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }
}
