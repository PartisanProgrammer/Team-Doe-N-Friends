using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Respawn SO", menuName = "Respawn")]
public class RespawnSO : ScriptableObject{
    public Vector3 RespawnPosition{ get; set; }
}
