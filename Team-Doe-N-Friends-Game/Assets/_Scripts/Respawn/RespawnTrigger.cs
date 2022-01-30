using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour{
    [SerializeField] CharacterHolderSO characterHolderSo;
    [SerializeField] GameObject player;

    WorldSwitcher worldSwitcher;
    WorldController worldController;


    void Awake(){
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
        worldController = FindObjectOfType<WorldController>();
    }

    void Start(){
        player.transform.position = characterHolderSo.respawnSo.RespawnPosition;
        player.GetComponent<Rigidbody2D>().gravityScale = characterHolderSo.gravitySo.savedGravityScale;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            Respawn();
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            Respawn();

        }
    }


    public void Respawn(){
        if (characterHolderSo.lifeStateSo.isAlive && characterHolderSo.lifeStateSo.savedIsAliveState){
            worldController.SetWorldToAlive();
        }
        if (characterHolderSo.lifeStateSo.isAlive && !characterHolderSo.lifeStateSo.savedIsAliveState){
            worldController.SetWorldToDead();
            characterHolderSo.lifeStateSo.isAlive = false;
            characterHolderSo.Turn();
        }
        if (!characterHolderSo.lifeStateSo.isAlive && characterHolderSo.lifeStateSo.savedIsAliveState){
            worldController.SetWorldToAlive();
            characterHolderSo.lifeStateSo.isAlive = true;
            characterHolderSo.Turn();
        }
        if (!characterHolderSo.lifeStateSo && !characterHolderSo.lifeStateSo.savedIsAliveState){
            worldController.SetWorldToDead();
        }
            
            
        //characterHolderSo.lifeStateSo.isAlive = characterHolderSo.lifeStateSo.savedIsAliveState;
        characterHolderSo.ResetWorldStateToSavedWorldState();
        //worldSwitcher.ChangeWorld();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}