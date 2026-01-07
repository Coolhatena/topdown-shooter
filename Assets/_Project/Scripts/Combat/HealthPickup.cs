using UnityEngine;

public sealed class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Health hp = other.GetComponent<Health>();
        if (hp != null)
        {
            hp.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
