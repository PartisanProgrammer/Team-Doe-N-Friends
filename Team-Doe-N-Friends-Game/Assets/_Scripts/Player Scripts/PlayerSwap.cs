using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwap : MonoBehaviour{
    [SerializeField]Rigidbody2D rigidbody2D;
    [SerializeField] float lerpTimer = 0.5f;
    
    float timeElapsed;

    void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (Input.GetKey(KeyCode.R)){
            RotatePlayer();
        }
    }

    void RotatePlayer(){
        timeElapsed += lerpTimer * Time.deltaTime;
        while (rigidbody2D.gravityScale != -1){
            rigidbody2D.gravityScale = Mathf.Lerp(1,  -1, timeElapsed);
            var targetRotation = new Quaternion(0, 0, 180, 0);
            var currentRotation = new Quaternion(0, 0, 0, 0);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, timeElapsed);
        }
        


        //transform.rotation = transform.rotation(0, 0, Mathf.Lerp(0f, 180f, timeElapsed), 0);
        // if (timeElapsed > 1f){
        //     timeElapsed = 0;
        // }
            //transform.rotation.z =Mathf.Lerp( 0,  180, 1);
    }
}
