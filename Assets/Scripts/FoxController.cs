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
    public Vector3 locationStart;
    // Start is called before the first frame update

    public int score;
    private GlodCtr goldCtr;

    private GameManageCtr _gameManageCtr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sRder = GetComponent<SpriteRenderer>();
        FootFox = GameObject.Find("FootFox");
        aniFox = GetComponent<Animator>();

        //locationStart
        locationStart = new Vector3(-5, -2, 0);

        //score
        score = 0;

        //gameManageCtr
        _gameManageCtr = FindObjectOfType<GameManageCtr>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        
        if (checkOnGround())
        {
            float move = Input.GetAxis("Horizontal");
            if (move > 0f)
            {
                aniFox.SetInteger("StatusFox", 1);
                rb.velocity = new Vector2(move * speed, rb.velocity.y);
                sRder.flipX = false;
            }
            else if (move < 0f)
            {
                aniFox.SetInteger("StatusFox", 1);
                rb.velocity = new Vector2(move * speed, rb.velocity.y);
                sRder.flipX = true;
            }
            else
            {
                aniFox.SetInteger("StatusFox", 0);
            }

            if (Input.GetKeyDown("space"))
            {
                aniFox.SetInteger("StatusFox", 2);
                rb.velocity = new Vector2(rb.velocity.x, jumpHight);
            }
        }
        else
        {
            aniFox.SetInteger("StatusFox", 3);//drop
            float move = Input.GetAxis("Horizontal");
            if (move > 0f)
            {
                rb.velocity = new Vector2(move * speed, rb.velocity.y);
                sRder.flipX = false;
            }
            else if (move < 0f)
            {
                rb.velocity = new Vector2(move * speed, rb.velocity.y);
                sRder.flipX = true;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            goldCtr = collision.gameObject.GetComponents<GlodCtr>()[0];
            score += goldCtr.coinValue;
            //
            Destroy(collision.gameObject);
            //
            _gameManageCtr.LoadScore(score);
        }
            
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FlagCheckPoint" && collision.transform.position.x>locationStart.x)
        {
            locationStart = collision.gameObject.transform.position;
        }
    }

    void Update()
    {
        if (transform.position.y<-6)
        {

            //transform.position = locationStart;
            //StartCoroutine("Reswapn");
            StartCoroutine(Reswapn());
        }
    }


    IEnumerator Reswapn()
    {
        Debug.Log("Da vao");
        yield return new WaitForSeconds(2f);
        transform.position = locationStart;
    }
}
