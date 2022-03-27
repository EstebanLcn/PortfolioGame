using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    public static MoveBoss instance;
    private float moveSpeed = 4.5f;
    private bool facingTop = true;
    Vector3 pos, localScale;
    public bool enableMovement = true;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
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
        if (enableMovement)
        {
            pos += transform.up * Time.deltaTime * moveSpeed;
            transform.position = pos;
        }
    }
    void MoveBot()
    {
        if (enableMovement)
        {
            pos -= transform.up * Time.deltaTime * moveSpeed;
            transform.position = pos;
        }
    }
}
