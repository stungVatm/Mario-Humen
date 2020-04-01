using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer checkPointRender;
    public bool checkpointReached;

    void Start()
    {
        checkPointRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="MainFox")
        {
            checkPointRender.sprite = greenFlag;
            checkpointReached = true;
        }
    }

}
