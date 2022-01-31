using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnvironment : MonoBehaviour
{
    
    [SerializeField] bool shouldMove;
    [SerializeField] Vector2 maxMovement;
    [SerializeField] float moveSpeed;

    Vector2 startPosition;
    Vector2 endPosition;
    void Awake(){
        if (shouldMove){
            startPosition = transform.position;
            endPosition = startPosition + maxMovement;
        }
    }

    void Update(){
        if (shouldMove){
            var time = Mathf.PingPong((Time.time * moveSpeed), 1);
            transform.position = Vector2.Lerp(startPosition, endPosition, time);
        }
    }
}
