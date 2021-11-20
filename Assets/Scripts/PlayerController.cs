using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

       isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround );

        if (Input.GetButtonDown("Jump") )
        {
            if (isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

            }
        }

        if ( Input.GetKeyDown("left"))
        {
            anim.SetBool("isLeft", true);
        }
        else if ( Input.GetKeyDown("right"))
        {
            anim.SetBool("isLeft", false);

        }
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    
}
