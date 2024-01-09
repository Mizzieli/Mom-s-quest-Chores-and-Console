using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private bool _isJumping;
    private bool _isDucking;
    private bool _isSpeeding;

    private Rigidbody2D _rb;
    private Animator _anim;

    private GameManager _gameManager;
    public static PlayerMovement Instance { get; private set; }

    private int score; // New variable to store the player's score

    private ScoreManager scoreManager;

    void Start()
    {
        // Find the ScoreManager script in the scene
        scoreManager = FindObjectOfType<ScoreManager>();

        // Assign the Rigidbody2D component to _rb
        _rb = GetComponent<Rigidbody2D>();

        if (SpawnObstacle.Instance != null)
        {
            SpawnObstacle.OnObstacleSpawned += OnObstacleSpawned;
        }
    }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _anim = GetComponent<Animator>();
    }

    void OnObstacleSpawned()
    {
        Debug.Log("Obstacle spawned, do something in the player!");

        // Increment the score when an obstacle is spawned
        AddScore(1);
    }

    void OnDestroy()
    {
        if (SpawnObstacle.Instance != null)
        {
            SpawnObstacle.OnObstacleSpawned -= OnObstacleSpawned;
        }
    }

    void Update()
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Duck();
        }
    }

    void Duck()
    {
        if (_isDucking || _isJumping)
        {
            return;
        }

        //float duckForce = 10f;
        _isDucking = true;
        _anim.SetBool("Ducking", true);
        
        Invoke("StandUp", 0.25f);
        
        // _rb.AddForce(Vector2.down * duckForce, ForceMode2D.Force);
    }

    void Jump()
    {
        if (_isJumping || _isDucking)
        {
            return;
        }

        _rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }

    void StandUp()
    {
        _isDucking = false;
        _anim.SetBool("Ducking", _isDucking);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _isJumping = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger entered: " + col.tag);

        if (col.CompareTag("GoodObstacle"))
        {
            AddScore(1);
        }
        else if (col.CompareTag("BadObstacle"))
        {
            // Perform actions when a bad obstacle is triggered
        }
    }


    // New method to get the player's score
    public int GetScore()
    {
        return score;
    }

    // New method to add to the player's score
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreManager.UpdateScore(score);
    }
}
