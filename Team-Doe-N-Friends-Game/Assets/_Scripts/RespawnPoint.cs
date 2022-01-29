using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour{
    [SerializeField] RespawnSO respawnSO;
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            respawnSO.RespawnPosition = col.transform.position;
        }
    }
}
