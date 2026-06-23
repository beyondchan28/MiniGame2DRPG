using UnityEngine;

[CreateAssetMenu(fileName = "ChestData", menuName = "GameData/ChestData")]
public class ChestData : ScriptableObject
{
    public enum Type
    {
        HIT,
        AGILITY,
        ATTACK,
        DEFENSE
    }

    public Type ChestType;
    public int ValueOnOpen;
    [SerializeField] private DialogueManager.Chat openChat;
    [SerializeField] private DialogueManager.Chat closeChat;
    private DialogueManager.Chat chat;
    private bool isClosed = true;

    public void Setup()
    {
        chat = openChat;
    }

    public void AfterOpened()
    {
        isClosed = false;
        chat = closeChat;
    }

    public bool IsClosed()
    {
        return isClosed;
    }

    public DialogueManager.Chat GetChat()
    {
        return chat;
    }
}
