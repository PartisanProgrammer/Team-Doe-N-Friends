using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerMovement : MonoBehaviour{
    [Min(0)][SerializeField] float moveSpeed;
    [Min(0)][SerializeField] float sprintSpeed;
    [Range(0,10)][SerializeField] float timeUntilSprinting;

    //IsSprinting should determine if sprinting animation is active or not.
    public bool IsSprinting{
        get;
        private set;
    }

    internal float currentMoveSpeed;
    
    bool isStartingToSprint;
    
    Rigidbody2D rigidbody;
    PlayerInputs playerInputs;
    GroundChecker groundChecker;

    void Awake(){
        playerInputs = GetComponent<PlayerInputs>();
        rigidbody = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();
    }


    void Update(){
        currentMoveSpeed = moveSpeed;
        // if (IsSprinting){
        //     currentMoveSpeed = sprintSpeed;
        // }
        //
        // if (groundChecker.IsGrounded){
        //     
        //     if (!IsSprinting){
        //
        //         if (!isStartingToSprint){
        //             StartCoroutine(StartSprinting());
        //         }
        //         
        //     }
        //     
        // }
        //
        //
        // else if (!groundChecker.IsGrounded){
        //
        //     if (IsSprinting){
        //         StopCoroutine(StartSprinting());
        //         IsSprinting = false;
        //         currentMoveSpeed = moveSpeed;
        //     }
        // }
        //
        //
        
        SetVelocity();
    }

    void SetVelocity(){
        //Set move Velocity
        var velocity = rigidbody.velocity;
        velocity = new Vector3(playerInputs.MoveInput * currentMoveSpeed, velocity.y, 0);
        rigidbody.velocity = velocity;
    }

    IEnumerator StartSprinting(){
        isStartingToSprint = true;
        yield return new WaitForSeconds(timeUntilSprinting);
        currentMoveSpeed = sprintSpeed;
        IsSprinting = true;
        isStartingToSprint = false;

    }
}
