using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speedMovement = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public SpriteRenderer sprite;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speedMovement * Time.fixedDeltaTime);
        animator.SetFloat("speed", movement.sqrMagnitude);
        Flip(movement.x);
    }

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            sprite.flipX = false;
        }
        else if (velocity < -0.1f)
        {
            sprite.flipX = true;
        }
    }
}