using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScene2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelChangerBlackFade.instance.FadeToLevel(2);
    }
}
