using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour{
    [SerializeField] CharacterHolderSO characterHolderSo;
    
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            var gravity = col.GetComponent<Rigidbody2D>().gravityScale;
            characterHolderSo.respawnSo.RespawnPosition = col.transform.position;
            //characterHolderSo.gravitySo.gravityScale = gravity;
            //characterHolderSo.gravitySo.savedGravityScale = gravity;
            characterHolderSo.lifeStateSo.savedIsAliveState = characterHolderSo.lifeStateSo.isAlive;
            //characterHolderSo.worldStateSo.savedWorldIsInLightState = characterHolderSo.worldStateSo.worldIsInLightState;
        }
    }
}
