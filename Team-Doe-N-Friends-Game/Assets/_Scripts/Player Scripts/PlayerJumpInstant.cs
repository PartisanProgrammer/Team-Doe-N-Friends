using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
[DisallowMultipleComponent]
public class PlayerJumpInstant : MonoBehaviour
{
   
    [Min(0)][SerializeField] float minJumpHeight;
    [Min(0)][SerializeField] float maxJumpHeight;
    [Min(0)][SerializeField] float jumpChargeTime;
    [SerializeField] GravitySO gravitySo;
    [SerializeField] FMODUnity.EventReference JumpSound;

    PlayerAnimationSwitcher playerAnimationSwitcher;
    EventInstance jumpInstance;
   
    float jumpCharge;
    bool reversedGravitySettings;
    bool activeAnimation = true;
    
    PlayerInputs playerInputs;
    Rigidbody2D rigidbody2D;
    GroundChecker groundChecker;
    
    void Awake(){
        playerInputs = GetComponent<PlayerInputs>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();
        playerAnimationSwitcher = GetComponentInChildren<PlayerAnimationSwitcher>();
        jumpInstance = FMODUnity.RuntimeManager.CreateInstance(JumpSound);
        

        reversedGravitySettings = gravitySo.gravityIsReversed;
        if (reversedGravitySettings){
            rigidbody2D.gravityScale = -rigidbody2D.gravityScale;
        }
    }

    void FixedUpdate(){
        
        
        // if (groundChecker.IsGrounded && activeAnimation){
        //     animator.enabled = true;
        //     activeAnimation = false;
        //     
        // }
        
        //Jump Charging
        if (playerInputs.JumpInput){
            //This value increases as long as player holds space
            jumpCharge += Time.deltaTime / jumpChargeTime;
        }

        if (playerInputs.JumpInput){
            if (groundChecker.IsGrounded){
                //Lerps between min and max jump height.
                var jumpForce = Mathf.Lerp(minJumpHeight, maxJumpHeight, jumpCharge);
                PlayJumpSound();
                if (reversedGravitySettings){
                    rigidbody2D.AddForce(transform.up * -jumpForce);
                }
                else if(!reversedGravitySettings){
                    rigidbody2D.AddForce(transform.up * jumpForce); 
                }
                playerAnimationSwitcher.SetAnimatorDisabled();
                
            }
            jumpCharge = 0f;
        }
    }

    void PlayJumpSound(){
        jumpInstance.getPlaybackState(out var playbackState);
        if (playbackState == PLAYBACK_STATE.STOPPED){
            jumpInstance.start();
        }
    }
}
