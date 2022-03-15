using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    private float moveSpeed = 4.5f;
    private bool facingTop = true;
    Vector3 pos, localScale;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWhereToFace();
        if (facingTop)
        {
            MoveTop();
        }
        else
        {
            MoveBot();
        }
    }

    void CheckWhereToFace()
    {
        if (pos.y < -7f)
            facingTop = true;
        else if (pos.y > 7f)
            facingTop = false;
    }

    void MoveTop()
    {
        pos += transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos;
    }
    void MoveBot()
    {
        pos -= transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos;
    }
}
