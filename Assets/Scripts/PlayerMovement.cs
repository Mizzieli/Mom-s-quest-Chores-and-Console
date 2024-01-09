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

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _anim = GetComponent<Animator>();
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
    }

    void OnObstacleSpawned()
    {
        Debug.Log("Obstacle spawned, do something in the player!");
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
        Debug.Log("Update called");
        _rb.velocity = new Vector2(speed, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Duck();
        }
        else
        {
            StandUp();
        }
    }

    void Duck()
    {
        Debug.Log("Duck called");
        if (_isDucking || _isJumping)
        {
            return;
        }

        // Set the velocity directly to achieve ducking
        float duckSpeed = -10f; // Replace this value with your desired downward speed

        _rb.velocity = new Vector2(_rb.velocity.x, duckSpeed);
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
        if (col.CompareTag("GoodObstacle"))
        {
            _gameManager.AddScore(1);
        }
        else if (col.CompareTag("BadObstacle"))
        {
            // Perform actions when a bad obstacle is triggered
        }
    }
}