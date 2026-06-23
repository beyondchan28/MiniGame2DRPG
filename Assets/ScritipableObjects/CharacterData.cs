using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "GameData/CharacterData")]
public class CharacterData : ScriptableObject
{
    public int HitPoint = 3;
    public int AttackPoint = 1;
    public int DefensePoint = 1;
    public int Agility = 1;
    public DialogueManager.Chat OpeningChat = DialogueManager.Chat.NONE;
    public DialogueManager.Chat FightingChat = DialogueManager.Chat.NONE;
    public DialogueManager.Chat ClosingChat = DialogueManager.Chat.NONE;
}
