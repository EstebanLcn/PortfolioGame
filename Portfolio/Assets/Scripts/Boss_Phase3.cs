using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Phase3 : StateMachineBehaviour
{
    public GameObject star;
    public float timeLeftForStar = 5f;
    public float timeLeftBetweenSpawn = 2f;
    public bool canPointEffect = false;
    private int counter = 0;
    private GameObject _objectToBeDestroyed;
    public GameObject[] pointEffect;
    private float _destroyTime = 25;
    GameObject player;
    private bool canStar = true;
    private bool canLaser = true;
    public GameObject explosionLaser;
    private int counterShake = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Text txt = GameObject.Find("Canvas/BossPhaseName").GetComponent<Text>();
        txt.text = "";
        PlayerMovement2D.instance.enableX = false;
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(-8.6f, 0, 0);
        Weapon.instance.canShoot = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (canPointEffect && counter != 8)
        {
            if (timeLeftBetweenSpawn <= Time.deltaTime)
            {
                    _objectToBeDestroyed = Instantiate(pointEffect[counter]);
                    timeLeftBetweenSpawn = 1f;
                    counter++;
            }
            else
            {
                timeLeftBetweenSpawn -= Time.deltaTime;
            }
            Destroy(_objectToBeDestroyed, _destroyTime);
            if (counter == 8)
            {
                    canStar = false;
                    canPointEffect = false;
            }
        }
        else
        {
            if (canStar)
            {
                if (timeLeftForStar <= Time.deltaTime)
                {
                    Instantiate(star);
                    canPointEffect = true;
                }
                else
                {
                    timeLeftForStar -= Time.deltaTime;
                }
            }
            else
            {
                if (canLaser)
                {
                    if (timeLeftBetweenSpawn <= Time.deltaTime)
                    {
                        _objectToBeDestroyed = Instantiate(pointEffect[8]);
                        _objectToBeDestroyed = Instantiate(pointEffect[9]);
                        _objectToBeDestroyed = Instantiate(pointEffect[10]);
                        canLaser = false;
                        timeLeftBetweenSpawn = 0.5f;
                        PlayerHealthController.instance.Disappear();
                    }
                    else
                    {
                        timeLeftBetweenSpawn -= Time.deltaTime;
                    }
                    Destroy(_objectToBeDestroyed, _destroyTime);
                }
                else
                {
                    if(timeLeftBetweenSpawn <= Time.deltaTime)
                    {
                        _objectToBeDestroyed = Instantiate(explosionLaser, new Vector2(Random.Range(0, 0 - 20f), Random.Range(0 - 10f, 0 + 10f)), Quaternion.identity);
                        timeLeftBetweenSpawn = 0.5f;
                        counterShake++;
                    }
                    else
                    {
                        timeLeftBetweenSpawn -= Time.deltaTime;
                    }
                    Destroy(_objectToBeDestroyed, _destroyTime);
                    if(counterShake == 5)
                    {
                        CameraShake.instance.setTriggerShake();
                    }
                    if(counterShake == 10)
                    {
                        LevelChanger.instance.FadeToLevel(3);
                    }
                }
                
            }

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
