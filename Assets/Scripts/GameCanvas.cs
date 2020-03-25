using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public Text yourScore;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string scoreData = "Score: " + UserData.score;
        yourScore.text = scoreData;
    }
}
