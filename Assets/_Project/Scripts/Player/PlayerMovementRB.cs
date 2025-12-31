using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public sealed class PlayerMovementRB : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;

    private Rigidbody rb;
    private PlayerInputActions input;
    private Vector3 desiredVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerInputActions();
        Debug.Log("PlayerMovementRB Awake OK");
    }

    private void OnEnable()
    {
        input.Player.Enable();
        Debug.Log("Input Map Enabled");
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }

    private void Update()
    {
        Vector2 move = input.Player.Move.ReadValue<Vector2>();
        desiredVelocity = new Vector3(move.x, 0f, move.y) * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + desiredVelocity * Time.fixedDeltaTime);
    }
}
