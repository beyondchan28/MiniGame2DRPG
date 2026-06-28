using UnityEngine;

public class Interaction : MonoBehaviour
{
    public InteractionData Data;

    public bool IsHasChat()
    {
        return Data.GetChat() != DialogueManager.Chat.NONE;
    }

    public bool IsHasAction()
    {
        return Data.action != InteractionData.Action.NONE;
    }
}
