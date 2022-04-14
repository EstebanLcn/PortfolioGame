using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BossPhase2_5 : StateMachineBehaviour
{
    private string textUI = "BOSS PHASE SOFT SKILLS";
    GameObject child;
    GameObject childSlider;
    GameObject player;

    public GameObject[] words;

    Tilemap tilemap;

    private float _timeBetweenSpawn;
    private GameObject _objectToBeDestroyed;
    public float _startTimeBetweenSpawn;
    private float _destroyTime = 10;
    private int counter = 0;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public Animator animator;
    private Camera m_OrthographicCamera;

    public GameObject boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMovement2D.instance.enableY = false;
        Text txt = GameObject.Find("Canvas/BossPhaseName").GetComponent<Text>();
        txt.text = textUI;
        child = GameObject.Find("Canvas/ParentCinematic").transform.Find("CinematicBarsContainer").gameObject;
        child.SetActive(true);
        m_OrthographicCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        m_OrthographicCamera.orthographicSize = 7.0f;
        CameraFollow.instance.offset = new Vector3(0, 0, -10);
        childSlider = GameObject.Find("Canvas/Slider").gameObject;
        childSlider.SetActive(false);
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(0, 0, 0);
        MoveBoss.instance.enableMovement = false;
        boss = GameObject.Find("Boss");
        boss.transform.position = new Vector3(150, 0, 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_timeBetweenSpawn <= 0 && counter !=6)
        {
            if(counter % 2 == 0)
            {
                _objectToBeDestroyed = Instantiate(words[counter], new Vector2(spawnPointRight.position.x, spawnPointRight.position.y), Quaternion.identity);
                _timeBetweenSpawn = _startTimeBetweenSpawn;
                counter++;
            }
            else
            {
                _objectToBeDestroyed = Instantiate(words[counter], new Vector2(spawnPointLeft.position.x, spawnPointLeft.position.y), Quaternion.identity);
                _timeBetweenSpawn = _startTimeBetweenSpawn;
                counter++;
            }
            
        }
        else
        {
            _timeBetweenSpawn -= Time.deltaTime;
        }
        Destroy(_objectToBeDestroyed, _destroyTime);
        if (counter == 6)
        {
            if(_timeBetweenSpawn <= 0)
            {
                Boss.instance.setTriggerSkills();
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tilemap = GameObject.Find("Ground").GetComponent<Tilemap>();
        tilemap.color = new Color(1f, 1f, 1f, 1f);
        child.SetActive(false);
        m_OrthographicCamera.orthographicSize = 11.85284f;
        CameraFollow.instance.offset = new Vector3(7, 0, -10);
        childSlider.SetActive(true);
        boss.transform.position = new Vector3(16.97f, 1.89f, 0);
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
