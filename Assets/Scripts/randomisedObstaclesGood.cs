using UnityEngine;

public class randomisedObstaclesGood : MonoBehaviour
{
    public int pointsToAdd = 1;
    public GameObject popEffectPrefab;

    void OnMouseDown()
    {
        // Increase points by calling AddScore with the specified value
        GameManager.Instance.AddScore(pointsToAdd);

        // Instantiate pop effect
        Instantiate(popEffectPrefab, transform.position, Quaternion.identity);

        // Destroy the good obstacle
        Destroy(gameObject);
    }
}