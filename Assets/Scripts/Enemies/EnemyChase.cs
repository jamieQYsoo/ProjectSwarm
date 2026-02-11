using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 2f;

    Rigidbody2D rb;
    Transform target;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // simplest: find player once
        target = FindFirstObjectByType<PlayerMovement>().transform;
    }

    void FixedUpdate()
    {
        if (!target) return;
        Vector2 dir = ((Vector2)target.position - rb.position).normalized;
        rb.linearVelocity = dir * moveSpeed;
    }
}
