using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 3;
    int hp;
    public GameObject xpOrbPrefab;

    void Awake() => hp = maxHp;

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (xpOrbPrefab)
        {
            Instantiate(xpOrbPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
