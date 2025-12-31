using UnityEngine;

public sealed class TopDownCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new(0f, 12f, -8f);
    [SerializeField] private float smoothTime = 0.12f;

    private Vector3 vel;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desired = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref vel, smoothTime);
    }
}
