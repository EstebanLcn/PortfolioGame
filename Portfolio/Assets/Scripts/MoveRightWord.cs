using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightWord : MonoBehaviour
{
    private float moveSpeed = 4.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * moveSpeed;
    }
}
