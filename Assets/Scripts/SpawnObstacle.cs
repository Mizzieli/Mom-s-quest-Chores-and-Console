using System.Collections;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public static SpawnObstacle Instance { get; private set; }

    private GameManager _gameManager;

    public float timeBetweenSpawn = 1.0f;
    private float spawnTime;

    public float initialObstacleSpeed = 10.0f;
    public float maxObstacleSpeed = 30.0f;
    public float obstacleSpeedIncrementRate = 0.3f;
    private float currentObstacleSpeed;

    private Coroutine spawnCoroutine;

    public static event System.Action OnObstacleSpawned;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnGameStateChanged.AddListener(CheckState);

        currentObstacleSpeed = initialObstacleSpeed;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CheckState(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.Playing && spawnCoroutine == null)
        {
            spawnTime = Time.time + timeBetweenSpawn;
            spawnCoroutine = StartCoroutine(SpawnObstaclesCoroutine());
        }
        else if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator SpawnObstaclesCoroutine()
    {
        while (_gameManager.CurrentState == GameManager.GameState.Playing)
        {
            if (Time.time > spawnTime)
            {
                Spawn();
                spawnTime = Time.time + timeBetweenSpawn;

                currentObstacleSpeed = Mathf.Min(currentObstacleSpeed + obstacleSpeedIncrementRate * Time.deltaTime, maxObstacleSpeed);

                Debug.Log("Current Obstacle Speed: " + currentObstacleSpeed);
            }

            yield return null;
        }

        spawnCoroutine = null;
    }

    private void Spawn()
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);
        int randomObstacle = Random.Range(0, obstacles.Length);

        GameObject obstacle = Instantiate(obstacles[randomObstacle], spawnPoints[randomPoint].position, transform.rotation);

        Rigidbody2D obstacleRb = obstacle.GetComponent<Rigidbody2D>();
        if (obstacleRb != null)
        {
            obstacleRb.velocity = Vector2.left * currentObstacleSpeed;
        }

        OnObstacleSpawned?.Invoke();
    }

    void Update()
    {
        if (_gameManager.CurrentState == GameManager.GameState.Playing)
        {
            // Check if an obstacle should be spawned immediately when pressing spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Spawn();
                spawnTime = Time.time + timeBetweenSpawn;
            }
        }
    }
}
