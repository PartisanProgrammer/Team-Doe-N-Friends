using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerMovement : MonoBehaviour{
    [Min(0)][SerializeField] float moveSpeed;
    [Min(0)] [SerializeField] float maxSpeed;

    [SerializeField] LifeStateSO lifeState;


    //Dashing
    [SerializeField] float dashDuration;
    // [SerializeField] float doubleClickTime;
    [Min(0)] [SerializeField] float dashSpeed;
    [SerializeField] AnimationCurve animationCurve;

    [SerializeField] FMODUnity.EventReference footsteps;

    EventInstance _footstepInstance;

    bool IsDashing => Time.time < this.dashStart + dashDuration;
    bool doubleClickAvailable;
    float dashStart;
    float dashStrength;
    

    //IsSprinting should determine if sprinting animation is active or not.
    public bool IsSprinting{
        get;
        private set;
    }

    //internal float currentMoveSpeed;
    
    bool isStartingToSprint;
    
    Rigidbody2D rigidbody;
    PlayerInputs playerInputs;
    GroundChecker groundChecker;
    Vector2 dashDirection;

    void Awake(){
        playerInputs = GetComponent<PlayerInputs>();
        rigidbody = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();
        _footstepInstance = FMODUnity.RuntimeManager.CreateInstance(footsteps);
    }


    void Update(){
        if (IsDashing){
            SetDashVelocity();
        }
        else{
            CheckDashImput();
            SetVelocity();
        }
    }

    void CheckDashImput(){
        if (lifeState.isAlive){
            if (Input.GetKey(KeyCode.LeftShift)){
                if (Input.GetKeyDown(KeyCode.A)){ 
                    this.dashStart = Time.time; 
                    DashLeft();
                }
                else if (Input.GetKeyDown(KeyCode.D)){
                    this.dashStart = Time.time;
                    DashRight();
                }
            }
        }
        
    }

    void SetVelocity(){
        var velocity = rigidbody.velocity;
        velocity = new Vector2(playerInputs.MoveInput * moveSpeed, velocity.y);
        rigidbody.velocity = velocity;
    }
    
    void DashRight(){
        dashDirection = Vector2.right;
    }

    void DashLeft(){
        dashDirection = Vector2.left;
    }
    
    void SetDashVelocity(){
     
        float t = Mathf.InverseLerp(this.dashStart, this.dashStart + dashDuration, Time.time); // time between 0 and 1
        dashStrength = animationCurve.Evaluate(t);
        rigidbody.velocity = dashDirection * dashStrength * dashSpeed;
    }

    void playFootstepSound(){
        if (rigidbody.velocity.x > 0.5){
            _footstepInstance.getPlaybackState(out var playbackState);
            if (playbackState == PLAYBACK_STATE.STOPPED){
                _footstepInstance.start();
            }
        }
        else{
            _footstepInstance.stop(STOP_MODE.IMMEDIATE);
        }
    }


    // IEnumerator DoubleClickTimer(){
    //     doubleClickAvailable = true;
    //     yield return new WaitForSeconds(doubleClickTime);
    //     doubleClickAvailable = false;
    // }
}
