using System;
using UnityEditor;
using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField] private int maxHp = 5;

    public int MaxHp => maxHp;
    public int CurrentHp { get; private set; }

    public event Action<Health> Died;
    public event Action<int, int> Changed; // current, max

    private void Awake()
    {
        CurrentHp = maxHp;
        Changed?.Invoke(CurrentHp, maxHp);
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0 || CurrentHp <= 0) return;

        CurrentHp -= amount;
        if (CurrentHp < 0) CurrentHp = 0;

        Changed?.Invoke(CurrentHp, maxHp);

        if (CurrentHp <= 0)
        {
            Died?.Invoke(this);
        }
    }

    public void Heal(int amount)
    {
        if (amount <= 0 || CurrentHp <= 0) return;

        CurrentHp += amount;
        if (CurrentHp > maxHp) CurrentHp = maxHp;

        Changed?.Invoke(CurrentHp, maxHp);
    }
}
