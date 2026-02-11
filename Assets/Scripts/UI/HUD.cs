using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public PlayerHealth player;
    public TextMeshProUGUI hpText;

    void Update()
    {
        if (!player || !hpText) return;
        hpText.text = $"HP: {player.CurrentHp}/{player.MaxHp}";
    }
}