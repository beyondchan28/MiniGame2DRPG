using UnityEngine;

[CreateAssetMenu(fileName = "InteractionData", menuName = "GameData/InteractionData")]
public class InteractionData : ScriptableObject
{
    public enum HandOutType
    {
        NONE,
        HIT,
        AGILITY,
        ATTACK,
        DEFENSE
    }

    public HandOutType HandOutType;
    public float Value;
    public DialogueManager.Chat[] Chats;
}
