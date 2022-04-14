using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator animator;
    public static CameraShake instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setTriggerShake()
    {
        animator.SetTrigger("shake");
    }
}
