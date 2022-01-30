using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WorldSwitcher : MonoBehaviour{
    [SerializeField] GameObject lightWorld;
    [SerializeField] GameObject darkWorld;
    [SerializeField] float switchDuration;

    CharacterHolderSO characterHolderSo;

    void Awake(){
        characterHolderSo = FindObjectOfType<CharacterHolderSO>();

        
    }

    public void SwitchWorld(){
        StartCoroutine(ChangeWorldPlayerTimed());
    }

    public void ChangeWorld(){
        if (characterHolderSo.worldStateSo.savedWorldIsInLightState){
            lightWorld.SetActive(true);
            darkWorld.SetActive(false);
        }
        if (!characterHolderSo.worldStateSo.savedWorldIsInLightState){
            lightWorld.SetActive(false);
            darkWorld.SetActive(true);
        }
    }
    

    IEnumerator ChangeWorldPlayerTimed(){
        yield return new WaitForSeconds(0.3f);
        
        if (lightWorld.activeInHierarchy){
            lightWorld.SetActive(false);
            darkWorld.SetActive(true);
            characterHolderSo.worldStateSo.worldIsInLightState = false;
        }
        else if (darkWorld.activeInHierarchy){
            darkWorld.SetActive(false);
            lightWorld.SetActive(true); 
            characterHolderSo.worldStateSo.worldIsInLightState = true;
        }
    }

}
