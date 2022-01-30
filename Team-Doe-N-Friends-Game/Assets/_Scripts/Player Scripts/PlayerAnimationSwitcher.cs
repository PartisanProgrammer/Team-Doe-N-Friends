using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerAnimationSwitcher : MonoBehaviour{
   [SerializeField] RuntimeAnimatorController aliveRunningAnimController;
   [SerializeField] RuntimeAnimatorController deadRunningAnimController;
   [SerializeField] Animator animator;
   [HideInInspector] public bool canToggleAnimator = true;



   public void ChangeRunningAnimationController(){

      var animatorController = animator.runtimeAnimatorController;
      
      if (animatorController == aliveRunningAnimController){
         animator.runtimeAnimatorController = deadRunningAnimController;
      }
      else if (animatorController == deadRunningAnimController){
         animator.runtimeAnimatorController = aliveRunningAnimController;
      }
   }

   public void ToggleAnimation(){
      if (canToggleAnimator){
         if (animator.enabled){
            animator.enabled = false;
            StartCoroutine(ToggleTimer());

         }
         else if (animator.enabled == false){
            animator.enabled = true;
            StartCoroutine(ToggleTimer());
         }
      }
      
   }

   public void SetAnimatorDisabled(){
      animator.enabled = false;
   }

   public void SetAnimatorEnabled(){
      animator.enabled = true;
   }


   IEnumerator ToggleTimer(){
      canToggleAnimator = false;
      yield return new WaitForSeconds(0.1f);
      canToggleAnimator = true;
   }
}
