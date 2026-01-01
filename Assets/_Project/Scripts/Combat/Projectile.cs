using UnityEngine;

public sealed class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 18f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private int damage = 1;

    private Vector3 direction;

    public void Init(Vector3 dir)
    { 
        direction = dir.normalized;
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health hp = other.GetComponentInParent<Health>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
    }
}
