using UnityEngine;

public class randomisedObstaclesGood : MonoBehaviour
{
    public int pointsToAdd = 1;
    public GameObject popEffectPrefab;

    void OnMouseDown()
    {
        // Access the ScoreManager instance and call PlayerHitGoodObstacle
        GameManager.Instance.AddScore(pointsToAdd);

        // Instantiate pop effect
        Instantiate(popEffectPrefab, transform.position, Quaternion.identity);

        // Destroy the good obstacle
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the ScoreManager and call the AddScoreOnCollision method
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);
            }

            // Optionally, destroy the good object upon collision
            Destroy(gameObject);
        }
    }
}