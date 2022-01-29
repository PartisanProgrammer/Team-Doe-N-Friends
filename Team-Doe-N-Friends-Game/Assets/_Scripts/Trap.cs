using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour{
    Rigidbody2D rb2D;
    GravitySwap gravitySwap;

    float dot;

    void Start(){
        gravitySwap = FindObjectOfType<GravitySwap>();
        rb2D = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        dot = Vector3.Dot(rb2D.transform.up.normalized, this.transform.up);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            if (dot > 0.7 || dot < -0.7){
                gravitySwap.SwitchGravity();
            }
        }
    }
}
