using UnityEngine;

[System.Serializable]
public class EnemyEntry
{
    public GameObject prefab;
    [Min(0f)] public float weight = 1f;
}

public class EnemySpawner : MonoBehaviour
{
    public Transform player;

    [Header("Enemies (weighted)")]
    public EnemyEntry[] enemies;

    [Header("Spawn")]
    public float startInterval = 0.6f;   // inspector value stays stable
    public float spawnRadius = 12f;

    [Header("Difficulty Ramp")]
    public float intervalMinimum = 0.001f;   
    public float rampPerSecond = 0.05f;

    float timer;
    float currentInterval;

    void Awake()
    {
        currentInterval = startInterval;
    }

    void Update()
    {
        if (!player || enemies == null || enemies.Length == 0) return;

        // ramp difficulty (don’t mutate inspector field)
        currentInterval = Mathf.Max(intervalMinimum, currentInterval - rampPerSecond * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= currentInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject prefab = PickWeighted(enemies);
        if (!prefab) return;

        Vector2 dir = Random.insideUnitCircle.normalized;
        Vector3 pos = player.position + (Vector3)(dir * spawnRadius);
        Instantiate(prefab, pos, Quaternion.identity);
    }

    GameObject PickWeighted(EnemyEntry[] list)
    {
        float total = 0f;
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].prefab && list[i].weight > 0f)
                total += list[i].weight;
        }

        if (total <= 0f) return null;

        float r = Random.value * total;

        for (int i = 0; i < list.Length; i++)
        {
            var e = list[i];
            if (!e.prefab || e.weight <= 0f) continue;

            r -= e.weight;
            if (r <= 0f) return e.prefab;
        }

        // fallback
        for (int i = list.Length - 1; i >= 0; i--)
            if (list[i].prefab) return list[i].prefab;

        return null;
    }
}