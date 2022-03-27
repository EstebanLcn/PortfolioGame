using UnityEngine;
using UnityEngine.UI;

public class BossPhase2_5 : StateMachineBehaviour
{
    private string textUI = "BOSS PHASE SOFT SKILLS";
    GameObject originalGameObject;
    GameObject child;
    GameObject childSlider;
    GameObject player;

    public GameObject[] words;

    private float _timeBetweenSpawn;
    private GameObject _objectToBeDestroyed;
    public float _startTimeBetweenSpawn;
    private float _destroyTime = 10;
    private int counter = 0;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;

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
        childSlider = originalGameObject.transform.GetChild(6).gameObject;
        childSlider.SetActive(false);
        PlayerMovement2D.instance.enableY = false;
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(0, 0, 0);
        MoveBoss.instance.enableMovement = false;
        GameObject boss = GameObject.Find("Boss");
        boss.transform.position = new Vector3(150, 0, 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_timeBetweenSpawn <= 0)
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
