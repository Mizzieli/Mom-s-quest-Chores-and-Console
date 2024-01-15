using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void OnEnable()
    {
        ScoreManager scoreData = FindObjectOfType<ScoreManager>();
        pointsText.text = scoreData.GetScore() + "POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
 
    }
     
    
}
