using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Trap : MonoBehaviour{
    [SerializeField] float trapResetTime = 1;
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] CharacterHolderSO characterHolderSo;

    [SerializeField] bool activatesDeathMode;
    [SerializeField] bool shouldMove;
    [SerializeField] Vector2 maxMovementTrap;
    [SerializeField] float trapSpeed;
    [SerializeField] float movementDelay = 1f;

    WorldController worldController;
    GameObject player;
    Vector2 startPosition;
    Vector2 endPosition;
    
    bool canTrigger = true;


    void Awake(){
        worldController = FindObjectOfType<WorldController>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        characterHolderSo = FindObjectOfType<CharacterHolderSO>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
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

            if (activatesDeathMode){
                worldController.SetWorldToDead();
                characterHolderSo.Turn(); //Turns 180
            }
            else if (!activatesDeathMode){
                worldController.SetWorldToAlive();
                characterHolderSo.Turn(); //Turns 180
            }
            impulseSource.GenerateImpulse();
            StartCoroutine(ResetTrap());
            StartCoroutine(ProhibitMovement());
            
        }
    }

    IEnumerator ResetTrap(){
        canTrigger = false;
        yield return new WaitForSeconds(trapResetTime);
        canTrigger = true;
    }

    IEnumerator ProhibitMovement(){
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        yield return new WaitForSeconds(movementDelay);
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
