using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    private float score;
    
    //update is called once per frame

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            score = Time.time; // Use Time.time for testing
            scoreText.text = ((int)score).ToString();
        }
    }

}
