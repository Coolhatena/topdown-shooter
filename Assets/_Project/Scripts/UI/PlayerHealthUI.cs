using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHealthUI : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private Transform heartsContainer;
    [SerializeField] private Image heartPrefab;

    [Header("Visual")]
    [SerializeField] private Color fullColor = Color.red;
    [SerializeField] private Color emptyColor = new(1f, 1f, 1f, 0.25f);

    private readonly List<Image> hearts = new();

    private void Awake()
    {
        if (playerHealth == null)
        {
            playerHealth = FindFirstObjectByType<PlayerHealth>()?.GetComponent<Health>();
        }
    }

    private void OnEnable()
    {
        if (playerHealth == null) return;
        
        playerHealth.Changed += OnHealthChanged;
        OnHealthChanged(playerHealth.CurrentHp, playerHealth.MaxHp);
    }

    private void OnDisable()
    {
        if (playerHealth == null) return;
        
        playerHealth.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged(int current, int max)
    {
        EnsureHearts(max);

        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].color = i < current ? fullColor : emptyColor;
        }
    }

    private void EnsureHearts(int max)
    {
        while (hearts.Count < max)
        {
            Image img = Instantiate(heartPrefab, heartsContainer);
            hearts.Add(img);
        }

        while (hearts.Count > max)
        {
            Image last = hearts[^1];
            hearts.RemoveAt(hearts.Count - 1);
            Destroy(last.gameObject);
        }
    }
}
