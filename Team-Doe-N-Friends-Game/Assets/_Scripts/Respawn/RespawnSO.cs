using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Respawn SO", menuName = "Respawn")]
public class RespawnSO : ScriptableObject{
    [SerializeField] Vector2 startPosition;
    public Vector2 RespawnPosition{ get; set; }


    void OnEnable(){
        RespawnPosition = startPosition;
    }
    
}
