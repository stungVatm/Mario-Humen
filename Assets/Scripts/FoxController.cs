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
    private Animator aniFox;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sRder = GetComponent<SpriteRenderer>();
        FootFox = GameObject.Find("FootFox");
        aniFox = GetComponent<Animator>();
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

        if (checkOnGround())
        {
            if (Mathf.Abs(rb.velocity.x)>0f)
            {
                aniFox.SetInteger("StatusFox",1);
            }
            else
            {
                aniFox.SetInteger("StatusFox", 0);
            }
        }
        else
        {
            if (rb.velocity.y>0)
            {
                aniFox.SetInteger("StatusFox", 2);
            }
            else
            {
                aniFox.SetInteger("StatusFox", 3);
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
            return true;
        }
        return false;
    }

}
