using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScore : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private GameManager _gameManager;
    
    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _gameManager = FindObjectOfType<GameManager>();   
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GoodObstacle"))
        {
            _scoreManager.AddScore(1);
        }
    
        else if (col.CompareTag("BadObstacle"))
            {
                _gameManager.GameOverScreen();
            }
    }
}
