using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New World State", menuName = "World State")]
public class WorldStateSO : ScriptableObject{
    [SerializeField] public bool worldIsInLightState = true;
    [SerializeField] public bool savedWorldIsInLightState = true;

    void OnEnable(){
        worldIsInLightState = true;
        savedWorldIsInLightState = true;
    }
}
