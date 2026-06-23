using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "GameData/CharacterData")]
public class CharacterData : ScriptableObject
{
    public int Hit = 3;
    public int Attack = 1;
    public int Defense = 1;
    public int Agility = 1;
    public DialogueManager.Chat OpeningChat = DialogueManager.Chat.NONE;
    public DialogueManager.Chat FightingChat = DialogueManager.Chat.NONE;
    public DialogueManager.Chat ClosingChat = DialogueManager.Chat.NONE;
}
