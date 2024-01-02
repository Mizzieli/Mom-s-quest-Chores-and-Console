using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public delegate void ObstacleSpawnedAction();
    public static event ObstacleSpawnedAction OnObstacleSpawned;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
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

        // Invoke the event when an obstacle is spawned
        if (OnObstacleSpawned != null)
        {
            OnObstacleSpawned();
        }
    }
}