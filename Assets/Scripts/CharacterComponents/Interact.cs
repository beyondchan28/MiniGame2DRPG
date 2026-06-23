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
    [SerializeField] DialogueManager dialogueManager;

    [SerializeField] private Movement movement;

    Vector2 raycastDirection = Vector2.right;
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
                WhenChat();
                break;
        }
    }

    void WhenChat()
    {
        if (interactInput.action.WasPressedThisFrame())
        {
            dialogueManager.NextDialogue();
            if (dialogueManager.IsDialgoueDone()) ChangeState(State.WALK);
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
            if (detectedDeed != null) OnDetectDeed();
        }
        else detectedDeed = null;

    }

    void OnDetectDeed()
    {
        if (detectedDeed.IsHasOpeningChat())
        {
            ChangeState(State.CHAT);
        }
        else
        {
            ChangeState(State.FIGHT);
            // go to fighting
        }
    }

    void ChangeState(State state)
    {
        if (currentState == state)
        {
            Debug.Log("[WARNING] Changing State as same as currentState is illegal at the moment");
            return;
        }

        currentState = state;

        // NOTE: Logic AFTER changing state
        switch (currentState)
        {
            case State.WALK:
                movement.On();
                break;
            case State.CHAT:
                movement.Off();
                dialogueManager.Begin(detectedDeed.CharacterData.OpeningChat);
                break;
            case State.FIGHT:
                break;
        }
    }
}
