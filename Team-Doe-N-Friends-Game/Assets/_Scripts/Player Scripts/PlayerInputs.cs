using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour{
    [HideInInspector]
    public float MoveInput{
        get;
        private set;
    }

    [HideInInspector]
    public bool JumpInputDown{
        get;
        private set;
    }
    [HideInInspector]
    public bool JumpInputUp{
        get;
        private set;
    }
    
    [HideInInspector]
    public bool JumpInput{
        get;
        private set;
    }
  
    
    void Update()
    {
        MoveInput = Input.GetAxis("Horizontal"); 
        JumpInputDown = Input.GetKeyDown(KeyCode.Space);
        JumpInputUp = Input.GetKeyUp(KeyCode.Space);
        JumpInput = Input.GetKey(KeyCode.Space);
        
    }
}
