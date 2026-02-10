using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 2f;
    public int damage = 1;

    Vector2 dir;
    float t;

    public void Init(Vector2 direction)
    {
        dir = direction.normalized;
        t = 0f;
    }

    void Update()
    {
        transform.position += (Vector3)(dir * speed * Time.deltaTime);

        t += Time.deltaTime;
        if (t >= lifeTime) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var hp = other.GetComponent<EnemyHealth>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
