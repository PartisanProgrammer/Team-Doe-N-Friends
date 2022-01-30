using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WorldSwitcher : MonoBehaviour{
    [SerializeField] GameObject lightWorld;
    [SerializeField] GameObject darkWorld;
    [SerializeField] float switchDuration;

    CharacterHolderSO characterHolderSo;
    public static WorldSwitcher instance;

    void Awake(){
        characterHolderSo = FindObjectOfType<CharacterHolderSO>();

        
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        
    }

    public void SwitchWorld(){
        StartCoroutine(ChangeWorldPlayerTimed());
    }

    public void ChangeWorld(){
        if (!characterHolderSo.worldStateSo.savedWorldIsInLightState){
            ChangeWorldToAlive();
        }
        if (characterHolderSo.worldStateSo.savedWorldIsInLightState){
            ChangeWorldToDead();
        }
    }

    public void ChangeWorldToDead(){
        lightWorld.SetActive(false);
        darkWorld.SetActive(true);
    }
    public void ChangeWorldToAlive(){
        lightWorld.SetActive(true);
        darkWorld.SetActive(false);
    }
    

    IEnumerator ChangeWorldPlayerTimed(){
        yield return new WaitForSeconds(0.3f);
        
        if (characterHolderSo.worldStateSo.worldIsInLightState){
            lightWorld.SetActive(false);
            darkWorld.SetActive(true);
           // characterHolderSo.worldStateSo.worldIsInLightState = false;
        }
        else if (!characterHolderSo.worldStateSo.worldIsInLightState){
            darkWorld.SetActive(false);
            lightWorld.SetActive(true); 
           // characterHolderSo.worldStateSo.worldIsInLightState = true;
        }
    }

}
