using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelUp : MonoBehaviour
{
    public AutoShooter shooter;

    [Header("UI")]
    public GameObject panel;
    public Button button1;
    public Button button2;
    public Button button3;

    string[] options;
    bool awaitingChoice;

    void Start()
    {
        panel.SetActive(false);

        button1.onClick.AddListener(() => Apply(1));
        button2.onClick.AddListener(() => Apply(2));
        button3.onClick.AddListener(() => Apply(3));
    }

    public void RequestLevelUp(int newLevel)
    {
        if (awaitingChoice) return;

        Time.timeScale = 0f;
        awaitingChoice = true;

        options = new string[]
        {
            "Faster Fire (-0.08s)",
            "More Damage (+1)",
            "Faster Projectiles (x1.15)"
        };

        // Set button labels
        button1.GetComponentInChildren<TextMeshProUGUI>().text = "1) " + options[0];
        button2.GetComponentInChildren<TextMeshProUGUI>().text = "2) " + options[1];
        button3.GetComponentInChildren<TextMeshProUGUI>().text = "3) " + options[2];

        panel.SetActive(true);
    }

    void Update()
    {
        if (!awaitingChoice) return;

        if (Input.GetKeyDown(KeyCode.Alpha1)) Apply(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Apply(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Apply(3);
    }

    void Apply(int choice)
    {
        if (!shooter) return;

        if (choice == 1) shooter.fireInterval = Mathf.Max(0.12f, shooter.fireInterval - 0.08f);
        if (choice == 2) shooter.damage += 1;
        if (choice == 3) shooter.projectileSpeedMultiplier *= 1.15f;

        awaitingChoice = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}