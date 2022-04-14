using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowYAxis : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < -0.25)
        {
            Vector3 position = transform.position;
            position.y = (player.position + offset).y;
            transform.position = position;
        }
    }
}
