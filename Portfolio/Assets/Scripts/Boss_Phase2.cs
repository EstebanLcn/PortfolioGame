using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Boss_Phase2 : StateMachineBehaviour
{
    float timeLeft;
    Color targetColor;
    int i = 0;

    public Color startColor;
    public Color endColor;
    GameObject originalGameObject;
    GameObject child;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startColor = new Color(1f, 1f, 1f, 1f);
        endColor = new Color(1f, 0f, 0f, 1f);
        originalGameObject = GameObject.Find("Grid");
        child = originalGameObject.transform.GetChild(4).gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tilemap tilemap = GameObject.Find("Ground").GetComponent<Tilemap>();
        if (i < 15)
        {
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                tilemap.color = targetColor;

                // start a new transition
                targetColor = i%2 == 0 ? startColor : endColor;
                timeLeft = 0.7f;
                i++;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                tilemap.color = Color.Lerp(tilemap.color, targetColor, Time.deltaTime / timeLeft);

                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }
        else
        {
            child.SetActive(true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
