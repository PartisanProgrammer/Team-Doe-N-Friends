using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerJump : MonoBehaviour{

   [Min(0)][SerializeField] float minJumpHeight;
   [Min(0)][SerializeField] float maxJumpHeight;
   [Min(0)][SerializeField] float jumpChargeTime;
   [SerializeField] bool gravityIsReversed;
   
   float jumpCharge;
    
    PlayerInputs playerInputs;
    Rigidbody2D rigidbody2D;
    GroundChecker groundChecker;
    
    void Awake(){
        playerInputs = GetComponent<PlayerInputs>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();

        if (gravityIsReversed){
            rigidbody2D.gravityScale = -rigidbody2D.gravityScale;
        }
    }

    void Update(){
        //Jump
        if (playerInputs.JumpInput){
            //This value increases as long as player holds space
            jumpCharge += Time.deltaTime / jumpChargeTime;
        }

        if (playerInputs.JumpInputUp){
            if (groundChecker.IsGrounded){
                //Lerps between min and max jump height.
                var jumpForce = Mathf.Lerp(minJumpHeight, maxJumpHeight, jumpCharge);
                if (gravityIsReversed){
                    rigidbody2D.AddForce(Vector2.up * -jumpForce);
                }
                else if(!gravityIsReversed){
                   rigidbody2D.AddForce(Vector2.up * jumpForce); 
                }
                
            }
            jumpCharge = 0f;
        }
    }
}
