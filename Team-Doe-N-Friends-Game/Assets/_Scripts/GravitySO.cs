using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Gravity SO", menuName = "Gravity")]
public class GravitySO : ScriptableObject
{
    [SerializeField] public bool gravityIsReversed;
    [Range(-1,1)][SerializeField] public float gravityScale;

    public float savedGravityScale = 1;


    void OnEnable(){
        gravityScale = 1;
    }

    public void ReverseGravity(){
        gravityScale = -gravityScale;
    }
}
