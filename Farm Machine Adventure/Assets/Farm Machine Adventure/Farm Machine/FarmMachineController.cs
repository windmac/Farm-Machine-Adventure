using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmMachineController : MonoBehaviour
{
    public float speed =10f;
    public float jumpspeed = 100f;
    private float movement = 0f;
    private Rigidbody2D rigidbody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator animation;
    private Vector2 scale_temp;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        scale_temp = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");



        if (movement > 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            animation.SetBool("IsWalking", true);
            transform.localScale = new Vector2(scale_temp.x, scale_temp.y);
        }
        else if(movement < 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            animation.SetBool("IsWalking", true);
            transform.localScale = new Vector2(-scale_temp.x, scale_temp.y);
        }
        else
        {
            animation.SetBool("IsWalking", false);
        }
        

        if(Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed);
           
        }

        if (Input.GetKey("down") && isTouchingGround)
        {
            animation.SetBool("IsSitting", true);
        }
        else
        {
            animation.SetBool("IsSitting", false);
        }

        animation.SetBool("OnGround", isTouchingGround);
    }
}
