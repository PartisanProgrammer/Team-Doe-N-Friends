using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GravitySwap : MonoBehaviour{

    [SerializeField] float rotationDuration = 0.5f;

    Rigidbody2D rigidbody2D;
    float timeStart;
    float gravity = -1;

    void Awake(){
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void SwitchGravity(){
        transform.Rotate(Vector3.forward,180);
        rigidbody2D.gravityScale = gravity;
        if (gravity == 1){
            gravity = -1;
        }
        else if (gravity == -1){
            gravity = 1;
        }
        
    }
}
