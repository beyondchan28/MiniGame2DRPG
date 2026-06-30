using UnityEngine;

public class Interaction : MonoBehaviour
{
    public InteractionData Data;
    [SerializeField]
    private string guid;

    public string Guid => guid;

    private void Awake()
    {
#if UNITY_EDITOR
        // Generate a GUID only once while editing.
        if (!Application.isPlaying)
        {
            GenerateGuid();
        }
#endif
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        GenerateGuid();
    }

    private void GenerateGuid()
    {
        if (string.IsNullOrEmpty(guid))
        {
            guid = System.Guid.NewGuid().ToString();
            UnityEditor.EditorUtility.SetDirty(this);
        }
    }
#endif

    public bool IsHasChat()
    {
        return Data.GetChat() != DialogueManager.Chat.NONE;
    }

    public void AfterInteract()
    {
        if (WorldData.Instance.IsInteracted(guid)) return;
        Data.AfterInteract();
        WorldData.Instance.Interacted(guid);
        OnAfterInteract();
    }

    protected virtual void OnAfterInteract() { }

}
