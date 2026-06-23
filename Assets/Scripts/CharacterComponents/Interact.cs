using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    enum State
    {
        WALK,
        CHAT,
        FIGHT,
    }

    [SerializeField] private InputActionReference interactInput;
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask interactLayer;

    Vector2 raycastDirection = Vector2.right;

    [SerializeField] DialogueManager dialogueManager;
    State currentState = State.WALK;
    Deed detectedDeed = null;

    void OnEnable()
    {
        interactInput.action.Enable();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.WALK:
                WhenWalk();
                break;
            case State.CHAT:
                if (interactInput.action.WasPressedThisFrame()) dialogueManager.NextDialogue();
                break;
        }
    }

    void WhenWalk()
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
            detectedDeed = hit.collider.GetComponentInParent<Deed>();
            if (detectedDeed != null) ChooseState();
        }
        else detectedDeed = null;

    }

    void ChooseState()
    {
        if (detectedDeed.IsHasOpeningChat())
        {
            currentState = State.CHAT;
            dialogueManager.Begin(detectedDeed.CharacterData.OpeningChat);
        }
        else
        {
            currentState = State.FIGHT;
            // go to fighting
        }
    }
}
