using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{

    public float jumpForce;
    public float speed;
    private bool isJumping;
    private bool isDoubleJumpAvailable;

    private Rigidbody2D rigibody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        if(Input.GetAxis("Horizontal") != 0f)
        {
            animator.SetBool("walk", true);
            if(Input.GetAxis("Horizontal") > 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }else {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                this.rigibody.AddForce(new Vector2(0f, this.jumpForce), ForceMode2D.Impulse);
                isDoubleJumpAvailable = true;
                animator.SetBool("jump", true);
            }
            else
            {
                if (isDoubleJumpAvailable)
                {
                    this.rigibody.AddForce(new Vector2(0f, this.jumpForce), ForceMode2D.Impulse);
                    isDoubleJumpAvailable = false;
                    animator.SetBool("jumpDouble", true);

                }
            }
        }
    }

    // detect if player is on the ground that is in the layer 8
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            animator.SetBool("onGround", true);
            animator.SetBool("jump", false);
            animator.SetBool("jumpDouble", false);
        }
    }

    // detect if player exit the ground that is in the layer 8
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
            animator.SetBool("onGround", false);
        }
    }
}
