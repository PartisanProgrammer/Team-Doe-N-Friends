using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Trap : MonoBehaviour{
    [SerializeField] float trapResetTime = 5;
    [SerializeField] CinemachineImpulseSource impulseSource;
    GravitySwap gravitySwap;
    WorldSwitcher worldSwitcher;

    bool canTrigger = true;
    

    void Start(){
        gravitySwap = FindObjectOfType<GravitySwap>();
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }


    void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player") && canTrigger){
            gravitySwap.SwitchGravity();
            worldSwitcher.SwitchWorld();
            impulseSource.GenerateImpulse();
            StartCoroutine(ResetTrap());
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.transform.CompareTag("Player") && canTrigger){
            gravitySwap.SwitchGravity();
            worldSwitcher.SwitchWorld();
            impulseSource.GenerateImpulse();
            StartCoroutine(ResetTrap());
        }
    }

    IEnumerator ResetTrap(){
        canTrigger = false;
        yield return new WaitForSeconds(trapResetTime);
        canTrigger = true;
    }
}
