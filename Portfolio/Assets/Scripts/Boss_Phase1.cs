using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Phase1 : StateMachineBehaviour
{
    public GameObject boss;
    public Transform spawnPoint;
    public GameObject[] words;
    private float _timeBetweenSpawn;
    private GameObject _objectToBeDestroyed;
    public float _startTimeBetweenSpawn;
    private float _destroyTime = 10;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnPoint = boss.transform.Find("WordSpawn");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_timeBetweenSpawn <= 0)
        {
           _objectToBeDestroyed = Instantiate(words[Random.Range(0, 10)], new Vector2(spawnPoint.position.x, Random.Range(spawnPoint.position.y - 2.7f, spawnPoint.position.y + 2.7f)), Quaternion.identity);
            _timeBetweenSpawn = _startTimeBetweenSpawn;
        }
        else
        {
            _timeBetweenSpawn -= Time.deltaTime;
        }
        Destroy(_objectToBeDestroyed, _destroyTime);
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
