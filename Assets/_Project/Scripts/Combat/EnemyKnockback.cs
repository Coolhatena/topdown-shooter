using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private float duration = 0.08f;
    [SerializeField] private float speed = 6f;

    private Rigidbody rb;
    private Vector3 dir;
    private float endTime;
    private bool active;

    public bool IsActive => active;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Apply(Vector3 direction)
    {
        direction.y = 0f;
        if (direction.sqrMagnitude < 0.0001f) return;

        dir = direction.normalized;
        active = true;
        endTime = Time.time + duration;
    }

    private void FixedUpdate()
    {
        if (!active) return;

        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        
        if (Time.time >= endTime)
        {
            active = false;
        }
    }
}
