using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    [Header("Contact Damage")]
    public int contactDamage = 1;
    public float damageTickSeconds = 0.5f;

    EnemyHealth health;

    void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }

    public void TakeDamage(int amount)
    {
        health.TakeDamage(amount);
    }

    public int ContactDamage => contactDamage;
    public float DamageTick => damageTickSeconds;
}
