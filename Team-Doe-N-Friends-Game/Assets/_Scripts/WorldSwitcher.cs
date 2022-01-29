using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WorldSwitcher : MonoBehaviour{
    [SerializeField] GameObject lightWorld;
    [SerializeField] GameObject darkWorld;
    [SerializeField] float switchDuration;
    [SerializeField] bool timedPlayerSwitcher;

    PlayerInputs playerInputs;

    int inactivePlayer = 1;

    void Awake(){
        playerInputs = FindObjectOfType<PlayerInputs>();

    }


    void Start(){
        if (timedPlayerSwitcher){
            StartCoroutine(ChangeWorldPlayerTimed());
        }
        
    }

    void Update(){

        if (!timedPlayerSwitcher){
            ChangeActiveWorld();
        }
        
    }

    void ChangeActiveWorld(){
       
        if (playerInputs.JumpInputUp){
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

    IEnumerator ChangeWorldPlayerTimed(){

        while (true){
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

}
