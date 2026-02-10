using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    public Projectile projectilePrefab;
    public float fireInterval = 0.6f;

    float timer;

    void Update()
    {
        if (!projectilePrefab) return;

        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            timer = 0f;
            ShootNearest();
        }
    }

    void ShootNearest()
    {
        var enemies = FindObjectsByType<EnemyChase>(FindObjectsSortMode.None);
        if (enemies.Length == 0) return;

        Transform nearest = enemies[0].transform;
        float best = (nearest.position - transform.position).sqrMagnitude;

        for (int i = 1; i < enemies.Length; i++)
        {
            float d = (enemies[i].transform.position - transform.position).sqrMagnitude;
            if (d < best) { best = d; nearest = enemies[i].transform; }
        }

        Vector2 dir = (nearest.position - transform.position).normalized;

        Projectile p = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        p.Init(dir);
    }
}
