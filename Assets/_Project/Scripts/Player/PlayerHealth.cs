using UnityEngine;

[RequireComponent(typeof(Health))]
public sealed class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float invulTime = 0.6f;
    
    private Health health;
    private PlayerDash dash;
    private float invulEndTime;

    private PlayerKnockback knockback;

    private void Awake()
    {
        health = GetComponent<Health>();
        dash = GetComponent<PlayerDash>();
        knockback = GetComponent<PlayerKnockback>();

        health.Died += onDied;
    }

    private void OnDestroy()
    {
        health.Died -= onDied;
    }

    public void TakeDamage(int amount, Vector3 knockDir)
    {
        if (Time.time < invulEndTime) return;
        if (dash != null && dash.IsDashing) return;

        health.TakeDamage(amount);
        invulEndTime = Time.time + invulTime;
        Debug.Log("Damage Taken");

        if (knockback != null)
        {
            knockback.Apply(knockDir);
        }
    }

    private void onDied(Health h)
    {
        Debug.Log("PLAYER DEAD");
        // Additional logic for player death (e.g., respawn, game over).
    }
}
