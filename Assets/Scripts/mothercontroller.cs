using System.Collections;
using UnityEngine;

public class mothercontroller : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float maxHorizontalDistance = 5f;
    public float startDelay = 5f;

    private bool movingRight = true;
    private GameManager _gameManager;
    private Transform target;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        // Set the target to the player's position
        target = FindObjectOfType<PlayerMovement>().transform;

        // Start coroutine for delayed movement.
        StartCoroutine(StartMovingAfterDelay());
    }

    void Update()
    {
        // Moves mother back and forth
        MoveMotherPlayer();
        CheckGameOver();
    }

    IEnumerator StartMovingAfterDelay()
    {
        // Wait for the specified delay before allowing movement
        yield return new WaitForSeconds(startDelay);

        // Mother in motion
        movingRight = true;
    }

    private void MoveMotherPlayer()
    {
        // Move towards the player
        float horizontalInput = movingRight ? 1f : -1f;
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);

        if (Mathf.Abs(transform.position.x - target.position.x) <= 0.5f)
        {
            // If the mother gets close enough to the player, game over
            _gameManager.GameOver();
        }

        if (Mathf.Abs(transform.position.x) >= maxHorizontalDistance)
        {
            // Change direction when reaching the maximum distance
            movingRight = !movingRight;
        }
    }

    private void CheckGameOver()
    {
        if (transform.position.y <= 0f)
        {
            _gameManager.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Game over logic (e.g., call _gameManager.GameOver())
            _gameManager.GameOver();
        }
    }

}