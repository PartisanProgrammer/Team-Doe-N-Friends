using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolderSO : MonoBehaviour{
   [SerializeField] public GravitySO gravitySo;
   [SerializeField] public LifeStateSO lifeStateSo;
   [SerializeField] public RespawnSO respawnSo;
   [SerializeField] public WorldStateSO worldStateSo;
   [SerializeField] public WorldSwitcher worldSwitcher;


   Rigidbody2D rigidbody2D;

   void Awake(){
      rigidbody2D = GetComponent<Rigidbody2D>();
      worldSwitcher = FindObjectOfType<WorldSwitcher>();
      
      
   }

   void Start(){
      if (lifeStateSo.savedIsAliveState){
         rigidbody2D.gravityScale = 1;
      }
      else{
         rigidbody2D.gravityScale = -1;
      }
   }


   public void Turn(){
      transform.Rotate(transform.right, 180,Space.World);
   }
   

   // public void ChangeGravity(){
   //    gravitySo.ReverseGravity();
   //    GetComponent<Rigidbody2D>().gravityScale = gravitySo.gravityScale;
   // }
   //
   // public void ChangeLifeState(){
   //    if (lifeStateSo.isAlive){
   //       lifeStateSo.isAlive = false;
   //    }
   //    else if (!lifeStateSo.isAlive){
   //       lifeStateSo.isAlive = true;
   //    }
   // }
   //
   // public void ChangeWorldState(){
   //    if (worldStateSo.worldIsInLightState){
   //       worldStateSo.worldIsInLightState = false;
   //    }
   //    else if (!worldStateSo.worldIsInLightState){
   //       worldStateSo.worldIsInLightState = true;
   //    }
   // }
   //
   // public bool WorldIsInLightState{
   //    get{
   //       return worldStateSo.worldIsInLightState;
   //    }
   //    set{
   //       worldStateSo.worldIsInLightState = value;
   //       worldSwitcher.ChangeWorld();
   //    }
   // }
   //
   // public void SetAliveState(){
   //    gravitySo.gravityScale = 1;
   //    gravitySo.savedGravityScale = 1;
   //    rigidbody2D.gravityScale = gravitySo.gravityScale;
   //   // gravitySwap.SwitchGravity();
   //    lifeStateSo.isAlive = true;
   //    worldSwitcher.ChangeWorld();
   //    worldStateSo.worldIsInLightState = true;
   //    worldStateSo.savedWorldIsInLightState = true;
   // }
   // public void SetDeadState(){
   //    gravitySo.gravityScale = -1;
   //    gravitySo.savedGravityScale = -1;
   //    rigidbody2D.gravityScale = gravitySo.gravityScale;
   //    //Swap Gravity Method
   //   // gravitySwap.SwitchGravity();
   //    lifeStateSo.isAlive = false;
   //    //Swap Sprite Method
   //    worldSwitcher.ChangeWorld();
   //    worldStateSo.worldIsInLightState = false;
   //    worldStateSo.savedWorldIsInLightState = false;
   //    //Swap World Method
   //    
   // }

   public void SetPositiveGravity(){
      rigidbody2D.gravityScale = 1;
      gravitySo.gravityScale = 1;
      gravitySo.savedGravityScale = 1;
   }
   public void SetNegativeGravity(){
      rigidbody2D.gravityScale = -1;
      gravitySo.gravityScale = -1;
      gravitySo.savedGravityScale = -1;
   }

   public void ResetWorldStateToSavedWorldState(){
      worldStateSo.worldIsInLightState = worldStateSo.savedWorldIsInLightState;
   }

   // public void SaveWorldState(){
   //     worldStateSo.savedWorldIsInLightState = worldStateSo.worldIsInLightState;
   // }
}
