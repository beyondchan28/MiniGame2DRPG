using UnityEngine;

public class Deed : MonoBehaviour
{
    public ChestData ChestData;

    public CharacterData CharacterData;

    void Awake()
    {
        if (ChestData != null) ChestData.Setup();
    }

    public void AfterOpenChest()
    {
        if (ChestData.IsClosed())
        {
            Debug.Log("[INFO] Add " + ChestData.ChestType + " : " + ChestData.ValueOnOpen);
            ChestData.AfterOpened();
        }
    }

    public bool IsHasOpeningChat()
    {
        return CharacterData.OpeningChat != DialogueManager.Chat.NONE;
    }
}
