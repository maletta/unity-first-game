using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{

    public float JumpForce;
    public float Speed;
    private Rigidbody2D rigibody;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
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
        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            this.rigibody.AddForce(new Vector2(0f, this.JumpForce), ForceMode2D.Impulse);
        }
    }
}
