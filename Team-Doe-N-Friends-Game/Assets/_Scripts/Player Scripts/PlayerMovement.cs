using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using FMOD.Studio;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerMovement : MonoBehaviour{
    [Min(0)][SerializeField] float moveSpeed;
    [Min(0)] [SerializeField] float maxSpeed;
    [Min(0)] [SerializeField] float dashChargeReplenishTime;
    [Min(0)] [SerializeField] int dashCharges;

    [SerializeField] CinemachineImpulseSource impulseSource;

    [SerializeField] LifeStateSO lifeState;


    //Dashing
    [SerializeField] float dashDuration;
    // [SerializeField] float doubleClickTime;
    [Min(0)] [SerializeField] float dashSpeed;
    [SerializeField] AnimationCurve animationCurve;

    [SerializeField] FMODUnity.EventReference footsteps;
    [SerializeField] FMODUnity.EventReference LandingSound;
    [SerializeField] FMODUnity.EventReference Dash;

    EventInstance _footstepInstance;
    PlayerAnimationSwitcher playerAnimationSwitcher;

    bool IsDashing => Time.time < this.dashStart + dashDuration;
    bool doubleClickAvailable;
    bool hasRotatedLeft;
    bool activeAnimation = true;
    bool canPlayLandingSound = true;
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
        impulseSource = GetComponent<CinemachineImpulseSource>();
        playerAnimationSwitcher = GetComponentInChildren<PlayerAnimationSwitcher>();
        _footstepInstance = FMODUnity.RuntimeManager.CreateInstance(footsteps);
    }


    void Update(){
        
        var rotation = transform.rotation;
        if (Input.GetKeyDown(KeyCode.D) && hasRotatedLeft || Input.GetKeyDown(KeyCode.RightArrow) && hasRotatedLeft){
            hasRotatedLeft = false;
            transform.Rotate(0, -180, 0, Space.World);
        }
        else if (Input.GetKeyDown(KeyCode.A) && !hasRotatedLeft || Input.GetKeyDown(KeyCode.LeftArrow) && !hasRotatedLeft){
            hasRotatedLeft = true;
            transform.Rotate(0, 180, 0, Space.World);
        }
        
        //playerInputs.MoveInput > 0
        playFootstepSound();
        if (IsDashing){
            SetDashVelocity();
        }
        else{
            CheckDashImput();
            SetVelocity();
        }
    }

    void CheckDashImput(){
        if (!lifeState.isAlive){
            if (Input.GetKey(KeyCode.LeftShift) && dashCharges >0 ){

                if (hasRotatedLeft){
                    this.dashStart = Time.time; 
                    DashLeft();
                    FMODUnity.RuntimeManager.PlayOneShot(Dash);
                    StartCoroutine(ConsumeDashCharge());
                }
                else if (!hasRotatedLeft){
                    this.dashStart = Time.time;
                    DashRight();
                    FMODUnity.RuntimeManager.PlayOneShot(Dash);
                    StartCoroutine(ConsumeDashCharge());
                }
                
                // if (Input.GetKeyDown(KeyCode.A)&& dashCharges >0){ 
                //     this.dashStart = Time.time; 
                //     DashLeft();
                //     FMODUnity.RuntimeManager.PlayOneShot(Dash);
                //     StartCoroutine(ConsumeDashCharge());
                // }
                // else if (Input.GetKeyDown(KeyCode.D)&& dashCharges >0){
                //     this.dashStart = Time.time;
                //     DashRight();
                //     FMODUnity.RuntimeManager.PlayOneShot(Dash);
                //     StartCoroutine(ConsumeDashCharge());
                // }
            }
        }
        
    }

    IEnumerator ConsumeDashCharge(){
        impulseSource.GenerateImpulse();
        dashCharges--;
        yield return new WaitForSeconds(dashChargeReplenishTime);
        dashCharges++;
    }

    void SetVelocity(){
        var velocity = rigidbody.velocity;
        velocity = new Vector2(playerInputs.MoveInput * moveSpeed, velocity.y);
        rigidbody.velocity = velocity;
    }
    
    void DashRight(){
        dashDirection = Vector2.right;;
    }

    void DashLeft(){
        dashDirection = Vector2.left;
    }
    
    void SetDashVelocity(){
     //add dash sound
        float t = Mathf.InverseLerp(this.dashStart, this.dashStart + dashDuration, Time.time); // time between 0 and 1
        dashStrength = animationCurve.Evaluate(t);
        rigidbody.velocity = dashDirection * dashStrength * dashSpeed;
    }

    void playFootstepSound(){
        playerAnimationSwitcher.SetAnimatorDisabled();
        if (rigidbody.velocity.x > 0.12 && groundChecker.IsGrounded|| rigidbody.velocity.x < -0.12 && groundChecker.IsGrounded){
            playerAnimationSwitcher.SetAnimatorEnabled();
            _footstepInstance.getPlaybackState(out var playbackState);
            if (playbackState == PLAYBACK_STATE.STOPPED){
                _footstepInstance.start();
            }
        }
        else{
            _footstepInstance.stop(STOP_MODE.IMMEDIATE);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.transform.CompareTag("Ground") && canPlayLandingSound){
            FMODUnity.RuntimeManager.PlayOneShot(LandingSound);
            StartCoroutine(LandingSoundTimer());
        }
    }


    IEnumerator LandingSoundTimer(){
        canPlayLandingSound = true;
        yield return new WaitForSeconds(1);
        canPlayLandingSound = false;
    }
}
