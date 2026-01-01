using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class EnemyChaser : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float stopDistance = 1.2f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 toTarget = target.position - rb.position;
        toTarget.y = 0f; // Ignore vertical difference

        float dist = toTarget.magnitude;
        if (dist <= stopDistance) return;

        Vector3 dir = toTarget / dist;
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);

        if (dir.sqrMagnitude > 0.0001f)
        {
            rb.MoveRotation(Quaternion.LookRotation(dir, Vector3.up));
        }
    }

    public void SetTarget(Transform t) => target = t;
}
