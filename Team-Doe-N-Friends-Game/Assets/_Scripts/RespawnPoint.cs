using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public static Vector3 SpawnPoint{ get; private set; }

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            SpawnPoint = col.transform.position;
        }
    }
}
