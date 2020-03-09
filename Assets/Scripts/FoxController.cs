using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHight = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sRder;
    private GameObject FootFox;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sRder = GetComponent<SpriteRenderer>();
        FootFox = GameObject.Find("FootFox");
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0f) {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
            sRder.flipX = false;
        } else if(move < 0f)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
            sRder.flipX = true;
        }
        else
        {

        }

        if (Input.GetKeyDown("space"))
        {
            if (checkOnGround()) {
                rb.velocity = new Vector2(rb.velocity.x, jumpHight);
            }
        }
    }

    bool checkOnGround()
    {
        Vector2 point = FootFox.transform.position;
        Vector2 size = new Vector2(1f,0.5f);
        Collider2D[] results = new Collider2D[10];

        int a = Physics2D.OverlapBox(point, size, 0f, new ContactFilter2D(), results);
        if (a>1)
        {
            Debug.Log(a);
            return true;
        }
        return false;
    }

}
