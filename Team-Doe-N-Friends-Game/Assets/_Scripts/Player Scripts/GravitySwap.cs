using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class GravitySwap : MonoBehaviour{
    
    [SerializeField] CharacterHolderSO characterHolderSo;

    public void SwitchGravity(){
       // transform.Rotate(Vector3.forward, 180);
        var rotation = transform.rotation;
        //transform.rotation = new Quaternion(rotation.x, rotation.y, 0, rotation.w);

        transform.rotation = new Quaternion(0, rotation.y, rotation.z +180, rotation.w);
        
        
        characterHolderSo.ChangeGravity();
        
    }
}
