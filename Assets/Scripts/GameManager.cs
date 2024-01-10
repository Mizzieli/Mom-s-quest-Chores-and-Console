using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        WaitingForPlayerInput,
        Playing,
        GameOver
    }

    public UnityAction<GameState> OnStateChanged;
    public UnityEvent<GameState> OnGameStateChanged = new UnityEvent<GameState>();

    public static GameManager Instance { get; private set; }
    
    
    private GameState currentState = GameState.WaitingForPlayerInput;
    public event Action OnObstacleSpawned;
    
    public float currentObstacleSpeed;
    public float spawnTime;
    public float timeBetweenSpawn;

    public TextMeshProUGUI scoreVal;
    public TextMeshProUGUI endScoresVal;
    public TextMeshProUGUI inScoreText;
    public TextMeshProUGUI gameOverText;

    private int scores;
    private bool _spaceBarPressed;
    private ScoreManager scoreManager;

    // ... other GameManager code ...

    public bool SpaceBarPressed
    {
        get { return _spaceBarPressed; }
    }

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }
    }
    
    void Awake()
    {
        // Ensure there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
            return;
        }

        // Initialize other GameManager properties as needed
        // ...

        DontDestroyOnLoad(gameObject);
    }

    public GameState CurrentState
    {
        get { return currentState; }
        set
        {
            currentState = value;
            OnGameStateChanged.Invoke(currentState);
            OnStateChanged?.Invoke(currentState);
        }
    }

    void Update()
    {
        if (CurrentState == GameState.WaitingForPlayerInput)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame(); // You can define a custom method for starting the game
            }
        }
    }
    void StartGame()
    {
        // Your logic to initialize the game state
        CurrentState = GameState.Playing;
    }

    public void GameOver()
    {
        Debug.Log("Game over!");

        // Add your game over logic here
        gameOverText.text = "Game Over!";
        endScoresVal.text = $"Final Score: {scores}";
    }


    public void AddScore(int pointsToAdd)
    {
        if (Instance != null)
        {
            scores += pointsToAdd;
            scoreVal.text = $"{scores} POINTS";
        }
    }
    // Example method that adds score when a specific game event occurs
    public void HandleGameEvent()
    {
        if (scoreManager != null)
        {
           // scoreManager.AddScore(1); // Add 10 points to the score
        }
    }
}