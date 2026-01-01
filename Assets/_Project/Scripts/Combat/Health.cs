using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField] private int maxHp = 3;

    public int CurrentHp { get; private set; }

    private void Awake()
    {
        CurrentHp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0) return;

        CurrentHp -= amount;
        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
