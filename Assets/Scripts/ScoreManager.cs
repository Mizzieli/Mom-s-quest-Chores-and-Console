using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Ensure the score text is updated when the game starts
        UpdateScore(0);
    }

    // Method to update the score on the scoreboard
    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }
}
