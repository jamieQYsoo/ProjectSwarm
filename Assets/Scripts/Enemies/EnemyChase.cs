using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 0.5f;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (!player) return;

        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var ph = other.GetComponentInParent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(1);
        }
    }


}
