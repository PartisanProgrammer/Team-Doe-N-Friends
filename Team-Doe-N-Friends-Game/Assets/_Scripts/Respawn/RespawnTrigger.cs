using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour{
    [SerializeField] RespawnSO respawnSO;
    [SerializeField] GameObject player;
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Start(){
        player.transform.position = respawnSO.RespawnPosition;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}