using UnityEngine;

public sealed class EnemyShooter : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform muzzle;
    [SerializeField] private EnemyProjectile projectilePrefab;

    [Header("Timing")]
    [SerializeField] private float fireInterval = 1.2f;
    [SerializeField] private float fireJitter = 0.2f;

    [Header("Constraints")]
    [SerializeField] private float maxRange = 10f;

    private float nextFireTime;

    private void Start()
    {
        ScheduleNextShot();
    }

    public void SetTarget(Transform t) => target = t;

    private void Update()
    {
        if (target == null || muzzle == null || projectilePrefab == null) return;
        
        Vector3 toTarget = target.position - transform.position;
        toTarget.y = 0; // Ignore vertical difference for range check

        if (toTarget.sqrMagnitude > maxRange * maxRange) return;
        if (Time.time < nextFireTime) return;

        Fire(toTarget);
        ScheduleNextShot();
    }

    private void Fire(Vector3 toTarget)
    {
        Vector3 direction = toTarget.normalized;
        EnemyProjectile proj = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
        proj.Init(direction);
    }

    private void ScheduleNextShot()
    {
        float jitter = Random.Range(-fireJitter, fireJitter);
        nextFireTime = Time.time + Mathf.Max(0.05f, fireInterval + jitter);
    }
}
