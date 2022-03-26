using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speedMovement = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    private bool m_FacingRight = true;
    public static PlayerMovement2D instance;
    public bool enableY = true;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (enableY)
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.y = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speedMovement * Time.fixedDeltaTime);
        animator.SetFloat("speed", movement.sqrMagnitude);

        if (movement.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && m_FacingRight)
        {
            Flip();
        }
       
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}