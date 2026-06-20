using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "GameData/CharacterData")]
public class CharacterData : ScriptableObject
{
    public int hitPoint = 3;
    public int attackPoint = 1;
    public int defensePoint = 1;
    public int agility = 1;
    public Session session = Session.NONE;
    public State[] stateOrder;
}
