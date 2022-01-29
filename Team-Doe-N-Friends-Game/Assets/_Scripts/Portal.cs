using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
[DisallowMultipleComponent]
public class Portal : MonoBehaviour{
    WorldSwitcher worldSwitcher;

    void Awake(){
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.name);
        if (col.tag == "Player"){
            worldSwitcher.SwitchWorld();
        }
    }
}
