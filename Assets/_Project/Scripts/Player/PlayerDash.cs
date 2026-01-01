using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 14f;
    [SerializeField] private float dashDuration = 0.12f;
    [SerializeField] private float dashCooldown = 0.35f;

    private Rigidbody rb;
    private PlayerInputActions input;

    private Vector3 moveDir;
    private float dashEndTime;
    private float nextDashTime;
    private bool isDashing;

    public bool IsDashing => isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerInputActions();
    }

    private void OnEnable() => input.Player.Enable();
    private void OnDisable() => input.Player.Disable();

    private void Update()
    {
        Vector2 move = input.Player.Move.ReadValue<Vector2>();
        moveDir = new Vector3(move.x, 0f, move.y).normalized;
        if (input.Player.Dash.WasPressedThisFrame())
        {
            TryDash();
        }
    }

    private void TryDash()
    {
        if (Time.time < nextDashTime) return;
        if (moveDir.sqrMagnitude < 0.0001f) return;

        isDashing = true;
        dashEndTime = Time.time + dashDuration;
        nextDashTime = Time.time + dashCooldown;
    }

    private void FixedUpdate()
    {
        if (!isDashing) return;
        
        rb.MovePosition(rb.position + moveDir * dashSpeed * Time.fixedDeltaTime);

        if (Time.time >= dashEndTime)
        {
            isDashing = false;
        }
    }
}
