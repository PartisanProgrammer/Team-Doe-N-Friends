using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationSwitcher : MonoBehaviour{
   [SerializeField] AnimatorController aliveRunningAnimController;
   [SerializeField] AnimatorController deadRunningAnimController;
   [SerializeField] Animator animator;



   public void ChangeRunningAnimationController(){

      var animatorController = animator.runtimeAnimatorController;
      
      if (animatorController == aliveRunningAnimController){
         animator.runtimeAnimatorController = deadRunningAnimController;
      }
      else if (animatorController == deadRunningAnimController){
         animator.runtimeAnimatorController = aliveRunningAnimController;
      }
   }
}
