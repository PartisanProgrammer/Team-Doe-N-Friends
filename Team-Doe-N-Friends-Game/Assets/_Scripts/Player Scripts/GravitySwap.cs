using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class GravitySwap : MonoBehaviour{
    
    [SerializeField] CharacterHolderSO characterHolderSo;

    public void SwitchGravity(){
        StartCoroutine(DelayedRotation());
    }

    IEnumerator DelayedRotation(){
        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right, 180,Space.World);
        characterHolderSo.ChangeGravity();
    }
}
