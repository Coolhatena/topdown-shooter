using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Transform muzzle;
    [SerializeField] private Projectile projectilePrefab;

    [Header("Setup")]
    [SerializeField] private float fireRate = 6f; // Bullets x second
    [SerializeField] private float spread = 2f; // Degrees

    private float nextFireTime;

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            tryFire();
        }
    }

    private void tryFire()
    {
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + (1f / fireRate);
        fire();
    }

    private void fire()
    {
        Vector3 dir = muzzle.forward;

        // Semi random spread
        float angle = Random.Range(-spread, spread);
        dir = Quaternion.Euler(0f, angle, 0f) * dir;

        Projectile proj = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
        proj.Init(dir);
    }
}
