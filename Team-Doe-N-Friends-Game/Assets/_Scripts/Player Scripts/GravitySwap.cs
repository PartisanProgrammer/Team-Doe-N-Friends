using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class GravitySwap : MonoBehaviour{
    
    [SerializeField] CharacterHolderSO characterHolderSo;

    public void SwitchGravity(){
        transform.Rotate(Vector3.forward, 180);
        characterHolderSo.ChangeGravity();
        
    }
}
