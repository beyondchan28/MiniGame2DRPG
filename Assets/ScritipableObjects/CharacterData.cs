using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "GameData/CharacterData")]
public class CharacterData : ScriptableObject
{
    public float Health = 3f;
    public float Attack = 1f;
    public float Defense = 0.5f;
    public float Agility = 1f;
    public DialogueManager.Chat OpeningChat = DialogueManager.Chat.NONE;
    public DialogueManager.Chat FightingChat = DialogueManager.Chat.NONE;
    public DialogueManager.Chat ClosingChat = DialogueManager.Chat.NONE;
}
