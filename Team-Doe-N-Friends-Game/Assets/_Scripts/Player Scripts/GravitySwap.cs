using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GravitySwap : MonoBehaviour{

    [SerializeField] float rotationDuration = 0.5f;
    [SerializeField] CharacterHolderSO characterHolderSo;
    [SerializeField] AnimationCurve rotationCurve;
    float gravity = -1;
    float rotationStart;
    float currentRotation;

    public void SwitchGravity(){
        rotationStart = Time.time;
        var timeLenght = Time.time + rotationDuration;
        
        float t = Mathf.InverseLerp(this.rotationStart, this.rotationStart + rotationDuration, Time.time); // time between 0 and 1
        currentRotation = rotationCurve.Evaluate(t);
        transform.rotation = Quaternion.Lerp(this.transform.rotation,new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z+ 180,transform.rotation.w),t);
        transform.rotation = new Quaternion(0f,0f,currentRotation*180,0f);
        characterHolderSo.ChangeGravity();
        
    }
}
