using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 3;
    int hp;

    void Awake() => hp = maxHp;

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0) Destroy(gameObject);
    }
}
