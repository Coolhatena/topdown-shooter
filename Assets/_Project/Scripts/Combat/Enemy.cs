using UnityEngine;

[RequireComponent(typeof(Health))]
public sealed class Enemy : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.Died += OnDied;
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.Died -= OnDied;
        }
    }

    private void OnDied(Health h)
    {
        Die();
    }

    private void Die()
    {
        /*
         TODO: Add things like
            * Animation
            * Drop loot
            * Score
         */
        Destroy(gameObject);
    }
}
