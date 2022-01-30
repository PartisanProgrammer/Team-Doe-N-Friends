using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolderSO : MonoBehaviour{
   [SerializeField] public GravitySO gravitySo;
   [SerializeField] public LifeStateSO lifeStateSo;
   [SerializeField] public RespawnSO respawnSo;
   [SerializeField] public WorldStateSO worldStateSo;


   public void ChangeGravity(){
      gravitySo.ReverseGravity();
      GetComponent<Rigidbody2D>().gravityScale = gravitySo.gravityScale;
   }

   public void ChangeLifeState(){
      if (lifeStateSo.isAlive){
         lifeStateSo.isAlive = false;
      }
      else if (!lifeStateSo.isAlive){
         lifeStateSo.isAlive = true;
      }
   }

   public void ChangeWorldState(){
      if (worldStateSo.worldIsInLightState){
         worldStateSo.worldIsInLightState = false;
      }
      else if (!worldStateSo.worldIsInLightState){
         worldStateSo.worldIsInLightState = true;
      }
   }

   public void ResetWorldStateToSavedWorldState(){
      worldStateSo.worldIsInLightState = worldStateSo.savedWorldIsInLightState;
   }

   public void SaveWorldState(){
       worldStateSo.savedWorldIsInLightState = worldStateSo.worldIsInLightState;
   }
}
