using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeDanceIdle : StateMachineBehaviour
{
    Animator anim;
    public float  time = 2f;
    float timerSet;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timerSet = time;
        anim = animator.GetComponent<Animator>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(time<=0)
        {
            anim.SetTrigger("dance");
            time = timerSet;
        }
        else
        {
            time -= Time.deltaTime;
          
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim.ResetTrigger("dance");
    }


}
