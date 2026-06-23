using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 30f;

    private Vector2 velocity;

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        Vector2 currentScale = transform.localScale;
        if (moveInput.x > 0f) currentScale.x = 1;
        else if (moveInput.x < 0f) currentScale.x = -1;
        transform.localScale = currentScale;

        Vector2 targetVelocity = moveInput * maxSpeed;

        float rate = moveInput.sqrMagnitude > 0.01f ? acceleration : deceleration;

        velocity = Vector2.MoveTowards(
            velocity,
            targetVelocity,
            rate * Time.deltaTime
        );

        transform.position += (Vector3)(velocity * Time.deltaTime);
    }

    public void On() { enabled = true; }
    public void Off() { enabled = false; }
}
