using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private TextMeshProUGUI scoreIncreaseText;
   
    private Scores scoreData = new Scores();
    
    private void Start()
    {
        // Ensure the score text is updated when the game starts
        scoreData = SaveData.Load();
        scoreData.score = 0;
        
        UpdateScoreText();
    }   

    public int GetScore()
    {
        return scoreData.score;
    }

    // Method to add points to the score
    public void AddScore(int points)
    {
        //normal scoring
        scoreData.score += points;
        //high score
        if (scoreData.score>scoreData.highScore)
        {
            scoreData.highScore = scoreData.score;
        }
        UpdateScoreText();
    }

    // Method to update the score text in the UI
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + scoreData.score + "\nHigh Score: " + scoreData.highScore;;
        }
    }
    void DisplayScoreIncreaseText(int points)
    {
        if (scoreIncreaseText != null)
        {
            // Show the increase in score temporarily
            scoreIncreaseText.text = "+" + points;
            StartCoroutine(HideScoreIncreaseText());
        }
    }

    IEnumerator HideScoreIncreaseText()
    {
        yield return new WaitForSeconds(1.5f);  // Adjust the delay as needed
        scoreIncreaseText.text = "";  // Hide the score increase text
    }

    private void OnDestroy()
    {
        SaveData.Save(scoreData);
    }
}