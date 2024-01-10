using UnityEngine;

public class mothercontroller : MonoBehaviour
{
    public float speed = 5f;
    public float amplitude = 2f;
    public float raycastDistance = 1f; // Adjust the raycast distance based on your needs
    public Transform target;

    private float startTime;
    private bool canMove = false;

    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        startTime = Time.time;
        _gameManager.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    void Update()
    {
        if (canMove)
        {
            // Calculate the elapsed time since the start
            float elapsedTime = Time.time - startTime;

            // Oscillate the position on the x-axis using a sine wave
            float newX = Mathf.Sin(elapsedTime * speed) * amplitude;

            // Cast a ray to check for obstacles in the path
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(newX), raycastDistance);

            if (hit.collider == null || hit.collider.CompareTag("Player"))
            {
                // Move towards the target on the y-axis
                transform.position = new Vector2(newX, target.position.y);
            }
        }
    }

    void HandleGameStateChanged(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.Playing)
        {
            canMove = true;
        }
    }
}