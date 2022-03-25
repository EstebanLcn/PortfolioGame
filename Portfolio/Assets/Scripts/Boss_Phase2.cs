using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Boss_Phase2 : StateMachineBehaviour
{
    float timeLeft;
    float timeLeftEnd;
    float timeLeftReset;

    Color targetColor;
    int i = 0;

    public Color startColor;
    public Color endColor;
    GameObject originalGameObject;
    GameObject child;
    private bool canInstantiate = true;

    public GameObject[] jobRole;
    public GameObject[] jobLocation;
    public GameObject[] jobMission;
    public Transform[] spawner;

    public GameObject circleOutside;

    private GameObject jobRoleToDestroyed;
    private GameObject jobLocationToDestroyed;
    private GameObject jobMissionToDestroyed;

    private GameObject circleOutside1;
    private GameObject circleOutside2;
    private GameObject circleOutside3;

    private SpriteRenderer player;

    private int index = 0;
    private bool isDmg = false;
    private bool isWaitReset = true;

    private string textUI = "BOSS PHASE PROFESSIONAL EXPERIENCES";

    Tilemap tilemap;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startColor = new Color(1f, 1f, 1f, 1f);
        endColor = new Color(1f, 0f, 0f, 1f);
        originalGameObject = GameObject.Find("Grid");
        child = originalGameObject.transform.GetChild(4).gameObject;
        player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        Text txt = GameObject.Find("Canvas/BossPhaseName").GetComponent<Text>();
        txt.text = textUI;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tilemap = GameObject.Find("Ground").GetComponent<Tilemap>();
        if (isWaitReset)
        {
            if (i < 10)
            {
                if (canInstantiate)
                {
                    jobRoleToDestroyed = Instantiate(jobRole[index], new Vector2(spawner[index].position.x, spawner[index].position.y), Quaternion.identity);
                    circleOutside1 = Instantiate(circleOutside, new Vector2(spawner[index].position.x, spawner[index].position.y), Quaternion.identity);
                    jobLocationToDestroyed = Instantiate(jobLocation[index], new Vector2(spawner[index].position.x + 6f, spawner[index].position.y - 7f), Quaternion.identity);
                    circleOutside2 = Instantiate(circleOutside, new Vector2(spawner[index].position.x + 6f, spawner[index].position.y - 7f), Quaternion.identity);
                    jobMissionToDestroyed = Instantiate(jobMission[index], new Vector2(spawner[index].position.x, spawner[index].position.y - 14f), Quaternion.identity);
                    circleOutside3 = Instantiate(circleOutside, new Vector2(spawner[index].position.x, spawner[index].position.y - 14f), Quaternion.identity);
                    canInstantiate = false;
                }
                if (timeLeft <= Time.deltaTime)
                {
                    // transition complete
                    // assign the target color
                    tilemap.color = targetColor;

                    // start a new transition
                    targetColor = i % 2 == 0 ? startColor : endColor;
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
                if (!isDmg)
                {
                    if (timeLeftEnd <= Time.deltaTime)
                    {
                        child.SetActive(!child.activeSelf);
                        timeLeftEnd = 1.5f;
                        if (child.activeSelf == false)
                        {
                            isDmg = true;
                        }
                    }
                    else
                    {
                        timeLeftEnd -= Time.deltaTime;
                    }
                }
                else
                {
                    Destroy(jobRoleToDestroyed, 0.1f);
                    Destroy(circleOutside1, 0.1f);
                    Destroy(jobLocationToDestroyed, 0.1f);
                    Destroy(circleOutside2, 0.1f);
                    Destroy(jobMissionToDestroyed, 0.1f);
                    Destroy(circleOutside3, 0.1f);
                    i = 0;
                    canInstantiate = true;
                    isDmg = false;
                    isWaitReset = false;
                    tilemap.color = new Color(1f, 1f, 1f, 1f);
                    player.color = new Color(1f, 1f, 1f, 1f);
                    timeLeftReset = 2f;
                    if (index == 2)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                //animator.GetComponent<WaitScript>().Wait();
                //child.SetActive(false);

            }
        }
        else
        {
            if (timeLeftReset <= Time.deltaTime)
            {
                isWaitReset = true;
            }
            else
            {
                timeLeftReset -= Time.deltaTime;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(jobRoleToDestroyed, 0.1f);
        Destroy(circleOutside1, 0.1f);
        Destroy(jobLocationToDestroyed, 0.1f);
        Destroy(circleOutside2, 0.1f);
        Destroy(jobMissionToDestroyed, 0.1f);
        Destroy(circleOutside3, 0.1f);
        tilemap.color = new Color(1f, 1f, 1f, 1f);
        player.color = new Color(1f, 1f, 1f, 1f);
    }

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
