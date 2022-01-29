using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour{
    GravitySwap gravitySwap;
    WorldSwitcher worldSwitcher;

    void Start(){
        gravitySwap = FindObjectOfType<GravitySwap>();
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
    }


    void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")){
            gravitySwap.SwitchGravity();
                worldSwitcher.SwitchWorld();
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.transform.CompareTag("Player")){
            gravitySwap.SwitchGravity();
            worldSwitcher.SwitchWorld();
        }
    }
}
