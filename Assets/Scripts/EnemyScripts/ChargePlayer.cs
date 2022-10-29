using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlayer : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    public Rigidbody2D rb;
    bool charged = false;
    public Behaviour AIPathfinder;
    Vector2 mt;

    void FixedUpdate(){
        mt = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < minimumDistance && !charged){
            charged = true;
            AIPathfinder.enabled = false;
            Invoke("Charge", 1.5f);
        }
    }

    void Charge(){
        rb.AddForce(-mt*5, ForceMode2D.Impulse);
    }



}
