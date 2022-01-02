using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    
    private Animator anim;


    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

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
        if (knockBackCounter <= 0)
        {

            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

                }
            }

            if (Input.GetKeyDown("left"))
            {
                anim.SetBool("isLeft", true);
            }
            else if (Input.GetKeyDown("right"))
            {
                anim.SetBool("isLeft", false);

            }

           
        } else
        {
            knockBackCounter -= Time.deltaTime;
            if (anim.GetBool("isLeft") == true)
            {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
            else if (anim.GetBool("isLeft") == false)
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }

        }
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);
    }
    
}
