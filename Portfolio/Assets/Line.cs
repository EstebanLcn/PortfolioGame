using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            player = GameObject.Find("Player");
            player.transform.position = new Vector3(0, 0, 0);
        }
    }
}
