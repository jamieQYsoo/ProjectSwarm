using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class InvulnFlash : MonoBehaviour
{
    public float flashHz = 12f;

    PlayerHealth health;
    SpriteRenderer sr;

    void Awake()
    {
        health = GetComponent<PlayerHealth>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (!sr || health == null) return;

        if (health.IsInvulnerable)
        {
            // blink on/off
            bool on = Mathf.FloorToInt(Time.unscaledTime * flashHz) % 2 == 0;
            sr.enabled = on;
        }
        else
        {
            sr.enabled = true;
        }
    }
}
