using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToLastScene : MonoBehaviour
{    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            LevelChangerBlackFade.instance.FadeToLevel(5);
        }
    }
}
