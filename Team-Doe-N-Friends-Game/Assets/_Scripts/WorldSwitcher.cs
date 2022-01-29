using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WorldSwitcher : MonoBehaviour{
    [SerializeField] GameObject lightWorld;
    [SerializeField] GameObject darkWorld;
    [SerializeField] float switchDuration;
    public void SwitchWorld(){
        StartCoroutine(ChangeWorldPlayerTimed());
    }

    IEnumerator ChangeWorldPlayerTimed(){
        yield return new WaitForSeconds(switchDuration);
        
        if (lightWorld.activeInHierarchy){
            lightWorld.SetActive(false);
            darkWorld.SetActive(true);
        }
        else if (darkWorld.activeInHierarchy){
            darkWorld.SetActive(false);
            lightWorld.SetActive(true); 
        }
    }

}
