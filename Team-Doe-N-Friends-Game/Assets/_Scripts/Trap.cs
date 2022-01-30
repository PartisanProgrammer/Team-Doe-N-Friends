using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Trap : MonoBehaviour{
    [SerializeField] float trapResetTime = 5;
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] PlayerAnimationSwitcher playerAnimationSwitcher;
    [SerializeField] CharacterHolderSO characterHolderSo;
    
    [SerializeField] bool shouldMove;
    [SerializeField] Vector2 maxMovementTrap;
    [SerializeField] float trapSpeed;
    
    GravitySwap gravitySwap;
    WorldSwitcher worldSwitcher;
    Vector2 startPosition;
    Vector2 endPosition;
    
    bool canTrigger = true;
    

    void Start(){
        gravitySwap = FindObjectOfType<GravitySwap>();
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
        playerAnimationSwitcher = FindObjectOfType<PlayerAnimationSwitcher>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        characterHolderSo = FindObjectOfType<CharacterHolderSO>();
        if (shouldMove){
            startPosition = transform.position;
            endPosition = startPosition + maxMovementTrap;
        }
    }

    void Update(){
        if (shouldMove){
            var time = Mathf.PingPong((Time.time * trapSpeed), 1);
            transform.position = Vector2.Lerp(startPosition, endPosition, time);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.transform.CompareTag("Player") && canTrigger){
            characterHolderSo.ChangeLifeState();
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
