using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 5;
    public float invulnSeconds = 0.6f;

    int hp;
    float invulnTimer;

    public int CurrentHp => hp;
    public int MaxHp => maxHp;
    public bool IsInvulnerable => invulnTimer > 0f;

    public GameOverUI gameOverUI;

    void Awake() => hp = maxHp;

    void Update()
    {
        if (invulnTimer > 0f) invulnTimer -= Time.deltaTime;
    }

    public bool TakeDamage(int amount)
    {
        if (invulnTimer > 0f) return false;

        hp -= amount;
        invulnTimer = invulnSeconds;

        if (hp <= 0) Die();
        return true;
    }

    void Die()
    {
        Time.timeScale = 0f;
        gameOverUI?.Show();
    }
}
