using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour{
    [SerializeField] List<Rigidbody2D> rigidbodies2D;
    [SerializeField] float switchDuration;


    void Start(){
        StartCoroutine(ChangeActivePlayer());
    }

    IEnumerator ChangeActivePlayer(){
        int inactivePlayer = 1;
        
        while (true){
            yield return new WaitForSeconds(switchDuration);
            //inactivePlayer++;
            int rigidbodiesAmount = rigidbodies2D.Count;
            rigidbodies2D[inactivePlayer % rigidbodiesAmount].simulated = false;
            rigidbodies2D[++inactivePlayer % rigidbodiesAmount].simulated = true;
        }
      
        
    }
    
}
