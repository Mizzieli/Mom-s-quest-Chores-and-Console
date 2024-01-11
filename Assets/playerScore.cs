using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScore : MonoBehaviour
{
    private ScoreManager _scoreManager;
    
    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GoodObstacle"))
        {
            _scoreManager.AddScore(1);
        }
    }
}
