using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    [Header("Spawn")]
    public float spawnInterval = 0.6f;
    public float spawnRadius = 12f;

    [Header("Difficulty Ramp")]
    public float intervalMin = 0.001f;
    public float rampPerSecond = 0.05f;

    float timer;

    void Update()
    {
        if (!enemyPrefab || !player) return;

        // ramp difficulty
        spawnInterval = Mathf.Max(intervalMin, spawnInterval - rampPerSecond * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        Vector2 dir = Random.insideUnitCircle.normalized;
        Vector3 pos = player.position + (Vector3)(dir * spawnRadius);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
