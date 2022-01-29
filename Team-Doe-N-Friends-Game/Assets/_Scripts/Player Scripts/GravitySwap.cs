using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GravitySwap : MonoBehaviour{

    [SerializeField] float rotationDuration = 0.5f;

    Rigidbody2D rigidbody2D;
    bool shouldSwitchGravity;
    float timeStart;
    float gravity;

    void Awake(){
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update(){
        SwitchGravity();
    }

    void SwitchGravity(){
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            transform.Rotate(Vector3.forward,180);
            rigidbody2D.gravityScale = gravity;
        }

        gravity = gravity switch{
            1 => -1,
            -1 => 1,
            _ => 1
        };
    }
}
