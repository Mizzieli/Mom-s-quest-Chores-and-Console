using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    
    public void Show()
    {
        ScoreManager score = FindObjectOfType<ScoreManager>();
        gameObject.SetActive(true);
        pointsText.text = score.GetScore() + "POINTS";
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
