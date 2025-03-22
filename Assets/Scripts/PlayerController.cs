using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameplayController
{
    private Rigidbody2D rb;

    private float flySpeed = 1f;
    private bool isRight;

    public float jumpForce = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isRight = true;
    }

    void Update()
    {
        if(flySpeed < 3.5)
        {
            flySpeed += 0.00001f;
        }

        BirdFly();
    }

    void BirdFly()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (isRight )
        {
            rb.velocity = new Vector2(2.3f * flySpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-2.3f * flySpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        isRight = !isRight;

        ChangeDirection();
    }

    void ChangeDirection()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = -tempScale.x;
        transform.localScale = tempScale;
    }
}
