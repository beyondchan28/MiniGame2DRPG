using UnityEngine;

public class InteractionHandOut : Interaction
{
    [SerializeField] protected FightData playerFightData;

    bool isOpened = false;

    protected override void OnAfterInteract()
    {
        if (isOpened) return;
        switch (Data.pointType)
        {
            case InteractionData.PointType.HEALTH:
                playerFightData.Health += Data.value;
                break;
            case InteractionData.PointType.ATTACK:
                playerFightData.Attack += Data.value;
                break;
            case InteractionData.PointType.DEFENSE:
                playerFightData.Defense += Data.value;
                break;
            case InteractionData.PointType.AGILITY:
                playerFightData.Agility += Data.value;
                break;
        }
        Debug.Log($"[INFO] Got {Data.value} point of {Data.pointType}");
        isOpened = true;
    }
}
