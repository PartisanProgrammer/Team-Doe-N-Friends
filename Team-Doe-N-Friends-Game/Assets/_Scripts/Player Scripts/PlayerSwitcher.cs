using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour{
    [SerializeField] List<Rigidbody2D> rigidbodies2D;
    [SerializeField] float switchDuration;
    [SerializeField] bool timedPlayerSwitcher;

    PlayerInputs playerInputs;

    int inactivePlayer = 1;

    void Awake(){
        playerInputs = FindObjectOfType<PlayerInputs>();
    }


    void Start(){
        if (timedPlayerSwitcher){
            StartCoroutine(ChangeActivePlayerTimed());
        }
        
    }

    void Update(){

        ChangeActivePlayer();
    }

    void ChangeActivePlayer(){
       
        if (playerInputs.JumpInputDown){
            int rigidbodiesAmount = rigidbodies2D.Count;
            rigidbodies2D[inactivePlayer % rigidbodiesAmount].simulated = false;
            rigidbodies2D[++inactivePlayer % rigidbodiesAmount].simulated = true;
        }
    }

    IEnumerator ChangeActivePlayerTimed(){

        while (true){
            yield return new WaitForSeconds(switchDuration);
            //inactivePlayer++;
            int rigidbodiesAmount = rigidbodies2D.Count;
            rigidbodies2D[inactivePlayer % rigidbodiesAmount].simulated = false;
            rigidbodies2D[++inactivePlayer % rigidbodiesAmount].simulated = true;
        }
      
        
    }
    
}
