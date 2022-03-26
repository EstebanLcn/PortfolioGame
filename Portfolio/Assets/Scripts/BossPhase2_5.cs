using UnityEngine;
using UnityEngine.UI;

public class BossPhase2_5 : StateMachineBehaviour
{
    private string textUI = "BOSS PHASE SOFT SKILLS";
    GameObject originalGameObject;
    GameObject child;
    GameObject childSlider;
    GameObject player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Text txt = GameObject.Find("Canvas/BossPhaseName").GetComponent<Text>();
        txt.text = textUI;
        originalGameObject = GameObject.Find("Canvas");
        child = originalGameObject.transform.GetChild(8).gameObject;
        child.SetActive(true);
        Camera m_OrthographicCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        m_OrthographicCamera.orthographicSize = 7.0f;
        CameraFollow.instance.offset = new Vector3(0, 0, -10);
        GameObject boss = GameObject.Find("Boss");
        //boss.transform.position = new Vector3(150,0,0);
        childSlider = originalGameObject.transform.GetChild(6).gameObject;
        childSlider.SetActive(false);
        PlayerMovement2D.instance.enableY = false;
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(0, 0, 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
