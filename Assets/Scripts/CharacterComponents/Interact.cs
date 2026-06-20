using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{

    [SerializeField] private InputActionReference interactInput;
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask interactLayer;

    Vector2 raycastDirection = Vector2.right;

    void OnEnable()
    {
        interactInput.action.Enable();
    }

    void OnDisable()
    {
        interactInput.action.Disable();
    }

    void Update()
    {
        if (transform.localScale.x == 1f) raycastDirection = Vector2.right;
        else if (transform.localScale.x == -1f) raycastDirection = Vector2.left;
        Debug.DrawRay(
            transform.position,
            raycastDirection * distance,
            Color.red
        );

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.right,
            distance,
            interactLayer
        );

        if (hit.collider != null && interactInput.action.WasPressedThisFrame())
        {
            Debug.Log("Hit: " + hit.collider.name);
        }
    }
}
