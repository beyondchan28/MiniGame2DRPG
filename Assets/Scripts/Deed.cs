using UnityEngine;

public class Deed : MonoBehaviour
{
    public CharacterData CharacterData;

    public bool IsHasOpeningChat()
    {
        return CharacterData.OpeningChat != DialogueManager.Chat.NONE;
    }
}
