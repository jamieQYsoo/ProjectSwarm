using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyContactDamage : MonoBehaviour
{
    Enemy enemy;
    float nextDamageTime;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time < nextDamageTime) return;

        if (other.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(enemy.ContactDamage);
            nextDamageTime = Time.time + enemy.DamageTick;
        }
    }
}
