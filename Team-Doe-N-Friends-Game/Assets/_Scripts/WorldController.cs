using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] CharacterHolderSO characterHolderSo;
    
    PlayerAnimationSwitcher playerAnimationSwitcher;
    WorldSwitcher worldSwitcher;
    void Awake(){
        playerAnimationSwitcher = FindObjectOfType<PlayerAnimationSwitcher>();
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
        
        
    }

    void Start(){
        if (characterHolderSo.lifeStateSo.savedIsAliveState){
            SetWorldToAlive();
        }
        else{
            SetWorldToDead();
        }
    }

    public void SetWorldToDead(){
        worldSwitcher.ChangeWorldToDead(); //World Changing
        characterHolderSo.SetNegativeGravity(); //Gravity
        characterHolderSo.lifeStateSo.isAlive = false;//Dead, for dash 
        playerAnimationSwitcher.SetDeadAnimator(); //Animation
    }


    public void SetWorldToAlive(){
        worldSwitcher.ChangeWorldToAlive();//World Changing
        characterHolderSo.SetPositiveGravity();//Gravity
        characterHolderSo.lifeStateSo.isAlive = true; //Alive, for no dash
        playerAnimationSwitcher.SetAliveAnimator(); //Animation
    }
}
