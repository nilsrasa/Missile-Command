using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreText;
    private string score = "Score: {0}";
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.uiScore += updateScore;
        scoreText.text = string.Format(score, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateScore(int newScore){
        scoreText.text = string.Format(score, newScore);
    }
}
