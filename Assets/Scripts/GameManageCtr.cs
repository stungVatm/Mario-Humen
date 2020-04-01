using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManageCtr : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScore(int score)
    {
        textScore.text = "Score: " + score;
    }
}
