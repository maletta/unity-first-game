using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public int moveSpeed;
    public float jumpForce;
    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //direction = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * this.moveSpeed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            this.rb.AddForce(new Vector2(0f, this.jumpForce), ForceMode2D.Impulse);
        }
    }
}
