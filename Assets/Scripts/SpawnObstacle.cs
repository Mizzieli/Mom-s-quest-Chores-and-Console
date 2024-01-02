using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public static event System.Action OnObstacleSpawned;

    public float timeBetweenSpawn;
    private float spawnTime;

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);
        int randomObstacle = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObstacle], spawnPoints[randomPoint].position, transform.rotation);

        OnObstacleSpawned?.Invoke();
    }
}