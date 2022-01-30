using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Life State", menuName = "Life State")]
public class LifeStateSO : ScriptableObject{
   [SerializeField] public bool isAlive;
   internal bool savedIsAliveState = true;

   void OnEnable(){
      isAlive = true;
      savedIsAliveState = true;
   }
}
