using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int xp = 0;
    public int level = 1;
    public int xpToLevel = 5;

    public LevelUp levelUpManager;

    public void Add(int amt)
    {
        xp += amt;
        if (xp >= xpToLevel)
        {
            xp -= xpToLevel;
            level++;
            xpToLevel += 3;

            levelUpManager?.RequestLevelUp(level);
        }
    }
}
