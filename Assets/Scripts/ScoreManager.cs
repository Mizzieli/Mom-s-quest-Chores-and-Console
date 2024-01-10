using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private void Start()
    {
        // Ensure the score text is updated when the game starts
        score = 0;
        UpdateScoreText();
    }

    public void AddScoreOnCollision()
    {
        // Increase the score by the desired amount (e.g., 10 points)
        AddScore(10);
    }
    // Method to add points to the score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Method to update the score text in the UI
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Public method to update the score externally
    public void UpdateScore(int newScore)
    {
        score = newScore;
        UpdateScoreText();
    }
}