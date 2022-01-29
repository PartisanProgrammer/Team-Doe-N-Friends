using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class MusicAndAmbienceControl : MonoBehaviour{
    [SerializeField] FMODUnity.EventReference Ambience;
    [SerializeField] FMODUnity.EventReference Music;

    Rigidbody2D playerRB;
    EventInstance ambienceInstance;
    EventInstance musicInstance;

    void Awake(){
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance(Ambience);
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(Music);
        playerRB = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
    }

    void Start(){
        musicInstance.start();
        ambienceInstance.start();
    }

    void Update(){
        if (playerRB.gravityScale == -1){
            ambienceInstance.setParameterByName("LightSide", 0);
            musicInstance.setParameterByName("LightSide", 0);
        }

        if (playerRB.gravityScale == 1){
            ambienceInstance.setParameterByName("LightSide", 1);
            musicInstance.setParameterByName("LightSide", 1);
        }
    }
}
