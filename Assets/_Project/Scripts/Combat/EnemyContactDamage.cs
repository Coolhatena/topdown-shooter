using UnityEngine;

public sealed class EnemyContactDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private EnemyKnockback knockback;

    private void Awake()
    {
        knockback = GetComponent<EnemyKnockback>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        PlayerHealth ph = collision.collider.GetComponent<PlayerHealth>();
        if (ph == null) return;

        Vector3 playerKnockDir = collision.transform.position - transform.position;
        playerKnockDir.y = 0f;
        ph.TakeDamage(damage, playerKnockDir);

        if (knockback != null)
        {
            knockback.Apply(-playerKnockDir);
        }

    }
}
