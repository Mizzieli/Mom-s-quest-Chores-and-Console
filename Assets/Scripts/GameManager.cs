using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public int maxPlatformCount = 10;
    
    public enum GameState
    {
        WaitingForPlayerInput,
        Playing,
        GameOver
    }

    void Start()
    {
        // Set the initial state when the game starts
        CurrentState = GameState.WaitingForPlayerInput;
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
    private Coroutine spawnCoroutine;

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
                CurrentState = GameState.Playing;
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over!");
        GameOverScreen.Setup(scores);

        CurrentState = GameState.GameOver;
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    public void AddScore(int pointsToAdd)
    {
        if (Instance != null)
        {
            scores += pointsToAdd;
            scoreVal.text = $"{scores} POINTS";
            Debug.Log($"Added{pointsToAdd} points.Total score: {scores}");
        }
    }
}
