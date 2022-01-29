using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour{
    [SerializeField] RespawnSO respawnSO;
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            col.transform.position = respawnSO.RespawnPosition;
        }
    }
}