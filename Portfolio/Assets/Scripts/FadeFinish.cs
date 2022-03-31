using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeFinish : MonoBehaviour
{
    public Animator animator;
    public KeyCode finishFade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(finishFade))
        {
            FadeToLevel();
        }
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeIn");
    }
}
