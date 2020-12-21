using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : StateMachineBehaviour
{
    readonly int hashMeleeAttackA = Animator.StringToHash("MeleeAttackA");
    readonly int hashNextAction = Animator.StringToHash("NextAction");
    
    public int actionState = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (actionState == 0)
            ResetTriggers(animator);
        
        // =========================================
        
        MeleeAttack meleeAttack = animator.GetComponent<MeleeAttack>();
        
        meleeAttack.UpdateCanvas(actionState);        
    }
    
    private void ResetTriggers(Animator animator) // we want to reset triggers to prevent inputs from registering when the player returns back to idle state
    {
        animator.ResetTrigger(hashMeleeAttackA);
        animator.ResetTrigger(hashNextAction);
    }
}
