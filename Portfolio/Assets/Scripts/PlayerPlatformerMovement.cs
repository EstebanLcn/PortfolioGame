using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerMovement : MonoBehaviour
{
    public static PlayerPlatformerMovement instance;
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    private bool m_FacingRight = true;


    //public ParticleSystem impactEffect;
    // private bool wasOnGround;
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        if (theRB.velocity.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (theRB.velocity.x < 0 && m_FacingRight)
        {
            Flip();
        }


        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        //anim.SetBool("isGrounded", isGrounded);
    }
    void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
