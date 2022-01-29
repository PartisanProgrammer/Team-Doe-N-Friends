using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GravitySwap : MonoBehaviour{

    [SerializeField] float rotationDuration = 0.5f;
    [SerializeField] CharacterHolderSO characterHolderSo;
    
    float timeStart;
    float gravity = -1;

    public void SwitchGravity(){
        transform.Rotate(Vector3.forward,180);
       characterHolderSo.gravitySo.ReverseGravity();
        
    }
}
