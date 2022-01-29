using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour{
    [SerializeField] List<Rigidbody2D> rigidbodies2D;
    [SerializeField] float switchDuration;
    [SerializeField] bool timedPlayerSwitcher;
    [SerializeField] CinemachineVirtualCamera camera;

    PlayerInputs playerInputs;

    int inactivePlayer = 1;

    void Awake(){
        playerInputs = FindObjectOfType<PlayerInputs>();
        camera = FindObjectOfType<CinemachineVirtualCamera>();
    }


    void Start(){
        if (timedPlayerSwitcher){
            StartCoroutine(ChangeActivePlayerTimed());
        }
        
    }

    void Update(){

        if (!timedPlayerSwitcher){
            ChangeActivePlayer();
        }
        
    }

    void ChangeActivePlayer(){
       
        if (playerInputs.JumpInputDown){
            int rigidbodiesAmount = rigidbodies2D.Count;
            rigidbodies2D[inactivePlayer % rigidbodiesAmount].simulated = false;
            rigidbodies2D[++inactivePlayer % rigidbodiesAmount].simulated = true;
            camera.Follow = rigidbodies2D[inactivePlayer % rigidbodiesAmount].gameObject.transform;
        }
    }

    IEnumerator ChangeActivePlayerTimed(){

        while (true){
            yield return new WaitForSeconds(switchDuration);
            //inactivePlayer++;
            int rigidbodiesAmount = rigidbodies2D.Count;
            rigidbodies2D[inactivePlayer % rigidbodiesAmount].simulated = false;
            rigidbodies2D[++inactivePlayer % rigidbodiesAmount].simulated = true;
            camera.Follow = rigidbodies2D[inactivePlayer % rigidbodiesAmount].gameObject.transform;
        }
      
        
    }
    
}
