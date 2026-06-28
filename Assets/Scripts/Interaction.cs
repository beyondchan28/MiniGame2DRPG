using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private FightData playerFightData;
    public InteractionData Data;
    bool isOpened = false;

    void Awake()
    {
        Data.Setup();
    }

    public bool IsHasChat()
    {
        return Data.GetChat() != DialogueManager.Chat.NONE;
    }

    public void DoAction()
    {
        switch(Data.action)
        {
            case InteractionData.Action.FIGHT:
                break;
            case InteractionData.Action.HAND_OUT:
                if (isOpened) break;
                switch(Data.pointType)
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
                isOpened = true;
                Debug.Log($"[INFO] Got {Data.value} point of {Data.pointType}");
                break;
        }
    }
}
