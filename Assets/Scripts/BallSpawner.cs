using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;              // Prefab to spawn

    [Tooltip("In seconds")]
    public float spawnInterval = 2f;       // Time between spawns
    public Vector2 spawnArea = new(10f, 5f); // Area within which to spawn TODO

    [Tooltip("Maximum magnitude of the velocity")]
    public float maxVelocity = 10f;        // Maximum velocity magnitude

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnBallObject();
        }
    }

    void SpawnBallObject()
    {
        // Random position within spawn area bounds
        Vector3 randomPosition = new(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y/2, spawnArea.y/2),
            0
        );

        GameObject ballObject = Instantiate(ballPrefab, randomPosition, Quaternion.identity);

        
        if (ballObject.TryGetComponent<Rigidbody2D>(out var rb))
        {
            Vector2 randomVelocity = Random.insideUnitCircle.normalized * maxVelocity;

            rb.velocity = randomVelocity;
        }
    }
}
