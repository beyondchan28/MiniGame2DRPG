using UnityEngine;

public class Interaction : MonoBehaviour
{
    private InteractionData interactionData;

    private DialogueManager.Chat currentChat;
    private int currentChatIdx = 0;

    void Awake()
    {
        if (IsHasChat()) currentChat = interactionData.Chats[currentChatIdx];
    }

    public bool IsHasChat()
    {
        return interactionData.Chats.Length != 0;
    }

    public DialogueManager.Chat GetChat()
    {

    }
}
