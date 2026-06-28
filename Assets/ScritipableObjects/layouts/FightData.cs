using UnityEngine;

[CreateAssetMenu(fileName = "FightData", menuName = "GameData/FightData")]
public class FightData : ScriptableObject
{
    public float Health = 3f;
    public float Attack = 1f;
    public float Defense = 0.5f;
    public float Agility = 1f;
}
