using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Phase1_2 : StateMachineBehaviour
{
    public GameObject boss;
    public Transform spawnPoint;
    public GameObject[] words;
    private float _timeBetweenSpawn;
    private GameObject _objectToBeDestroyed;
    public float _startTimeBetweenSpawn;
    private float _destroyTime = 10;
    private int counter = 0;
    private string textUI = "BOSS PHASE HARD SKILLS - WEB DEVELOPMENT";

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Text txt = GameObject.Find("Canvas/BossPhaseName").GetComponent<Text>();
        txt.text = textUI;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_timeBetweenSpawn <= 0)
        {
            _objectToBeDestroyed = Instantiate(words[counter], new Vector2(spawnPoint.position.x, Random.Range(spawnPoint.position.y - 8f, spawnPoint.position.y + 8f)), Quaternion.identity);
            _timeBetweenSpawn = _startTimeBetweenSpawn;
            counter++;
        }
        else
        {
            _timeBetweenSpawn -= Time.deltaTime;
        }
        Destroy(_objectToBeDestroyed, _destroyTime);
        if (counter == 6)
        {
            counter = 0;
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
