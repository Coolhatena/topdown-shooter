using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerAimMouse : MonoBehaviour
{
    [SerializeField] private Transform visual;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float maxRayDistance = 500f;

    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
            if (visual == null) visual = transform;
        }
    }

    private void Update()
    {
        if (cam == null) return;

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = cam.ScreenPointToRay(mousePos);

        if (!Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, groundMask, QueryTriggerInteraction.Ignore))
        {
             return;
        }

        Vector3 dir = hit.point - transform.position;
        dir.y = 0f;

        if (dir.sqrMagnitude < 0.0001f)
        {
            return;
        }

        visual.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }
}
