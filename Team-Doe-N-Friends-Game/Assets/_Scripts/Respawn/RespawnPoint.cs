using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour{
    [SerializeField] CharacterHolderSO characterHolderSo;
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            characterHolderSo.respawnSo.RespawnPosition = col.transform.position;
            characterHolderSo.gravitySo.gravityScale = col.GetComponent<Rigidbody2D>().gravityScale;
        }
    }
}
