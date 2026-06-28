using UnityEngine;

[CreateAssetMenu(fileName = "InteractionData", menuName = "GameData/InteractionData")]
public class InteractionData : ScriptableObject
{
    public enum PointType
    {
        NONE,
        HEALTH,
        AGILITY,
        ATTACK,
        DEFENSE
    }

    public enum Action
    {
        NONE,
        FIGHT,
        HAND_OUT
    }

    [Header("Happen after chat or directly if no chat")]
    public Action action;

    [Header("Hand out parameters")]
    public PointType pointType;
    public float value;

    [Header("Chat enum")]
    [SerializeField] private DialogueManager.Chat interactChat;
    [SerializeField] private DialogueManager.Chat afterInteractChat;
    private DialogueManager.Chat chat;

    public void Setup()
    {
        chat = interactChat;
    }

    public void AfterInteract()
    {
        chat = afterInteractChat;
    }

    public DialogueManager.Chat GetChat()
    {
        return chat;
    }

}
