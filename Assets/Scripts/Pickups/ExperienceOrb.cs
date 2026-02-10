using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    public int amount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        var xp = other.GetComponent<PlayerExperience>();
        if (xp)
        {
            xp.Add(amount);
            Destroy(gameObject);
        }
    }
}
