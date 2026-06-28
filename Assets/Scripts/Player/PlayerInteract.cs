using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerInteract : MonoBehaviour
{
    enum State
    {
        WALK,
        CHAT,
        FIGHT,
    }

    [SerializeField] private FightData fightDataPlayer;
    [SerializeField] private InputActionReference interactInput;
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] private PlayerMovement playerMovement;

    Vector2 raycastDirection = Vector2.right;
    State currentState = State.WALK;
    Interaction detectedInteraction = null;

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
            if (dialogueManager.IsDialgoueDone())
            {
                detectedInteraction.Data.AfterInteract();
                if (detectedInteraction.IsHasAction())
                {
                    switch(detectedInteraction.Data.action)
                    {
                        case InteractionData.Action.FIGHT:
                            break;
                        case InteractionData.Action.HAND_OUT:
                            break;
                    }
                }
            }
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
            detectedInteraction = hit.collider.GetComponentInParent<Interaction>();
            if (detectedInteraction != null) OnDetectDeed();
        }
        else detectedInteraction = null;

    }

    void OnDetectDeed()
    {
        if (detectedInteraction.IsHasChat())
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

        switch (currentState)
        {
            case State.WALK:
                playerMovement.On();
                break;
            case State.CHAT:
                playerMovement.Off();
                dialogueManager.Begin(detectedInteraction.Data.GetChat());
                break;
            case State.FIGHT:
                break;
        }
    }
}
