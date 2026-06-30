using UnityEngine;

public class Interaction : MonoBehaviour
{
    public InteractionData Data;

    void Awake()
    {
        Data.Setup();
    }

    public bool IsHasChat()
    {
        return Data.GetChat() != DialogueManager.Chat.NONE;
    }

    public void AfterInteract()
    {
        Data.AfterInteract();
        OnAfterInteract();
    }

    protected virtual void OnAfterInteract() { }

}
