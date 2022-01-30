using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Trap : MonoBehaviour{
    [SerializeField] float trapResetTime = 5;
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] PlayerAnimationSwitcher playerAnimationSwitcher;
    GravitySwap gravitySwap;
    WorldSwitcher worldSwitcher;

    bool canTrigger = true;
    

    void Start(){
        gravitySwap = FindObjectOfType<GravitySwap>();
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
        playerAnimationSwitcher = FindObjectOfType<PlayerAnimationSwitcher>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.transform.CompareTag("Player") && canTrigger){
            gravitySwap.SwitchGravity();
            worldSwitcher.SwitchWorld();
            impulseSource.GenerateImpulse();
            playerAnimationSwitcher.ChangeRunningAnimationController();
            StartCoroutine(ResetTrap());
        }
    }

    IEnumerator ResetTrap(){
        canTrigger = false;
        yield return new WaitForSeconds(trapResetTime);
        canTrigger = true;
    }
}
