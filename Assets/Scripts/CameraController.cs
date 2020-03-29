using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FoxMain;
    private Vector3 positionCamera ;
    public float offset;
    public float changeCamera;
    void Start()
    {
        //offset = 5f;
        //changeCamera = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (FoxMain.GetComponent<SpriteRenderer>().flipX)
        {
            positionCamera = new Vector3(FoxMain.transform.position.x - offset, transform.position.y, transform.position.z);
        }
        else
        {
            positionCamera = new Vector3(FoxMain.transform.position.x + offset, transform.position.y, transform.position.z);
        }
        
        transform.position =  Vector3.Lerp(transform.position,positionCamera,changeCamera*Time.deltaTime);
    }
}
