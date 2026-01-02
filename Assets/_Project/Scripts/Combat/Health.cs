using System;
using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField] private int maxHp = 5;

    public int CurrentHp { get; private set; }
    public event Action<Health> Died;

    private void Awake()
    {
        CurrentHp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0 || CurrentHp <= 0) return;

        CurrentHp -= amount;
        if (CurrentHp <= 0)
        {
            Died?.Invoke(this);
            // Die();
        }
    }

    /*
    private void Die()
    {
        Destroy(gameObject);
    }
    */
}
