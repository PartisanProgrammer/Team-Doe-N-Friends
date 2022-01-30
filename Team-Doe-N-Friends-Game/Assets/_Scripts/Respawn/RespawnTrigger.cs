using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour{
    [SerializeField] CharacterHolderSO characterHolderSo;
    [SerializeField] GameObject player;

    WorldSwitcher worldSwitcher;


    void Awake(){
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
    }

    void Start(){
        player.transform.position = characterHolderSo.respawnSo.RespawnPosition;
        player.GetComponent<Rigidbody2D>().gravityScale = characterHolderSo.gravitySo.savedGravityScale;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            characterHolderSo.lifeStateSo.isAlive = characterHolderSo.lifeStateSo.savedIsAliveState;
            characterHolderSo.ResetWorldStateToSavedWorldState();
            worldSwitcher.ChangeWorld();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            characterHolderSo.lifeStateSo.isAlive = characterHolderSo.lifeStateSo.savedIsAliveState;
            characterHolderSo.ResetWorldStateToSavedWorldState();
            worldSwitcher.ChangeWorld();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}