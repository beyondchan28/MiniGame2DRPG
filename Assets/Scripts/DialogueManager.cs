using UnityEngine;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public enum Session
    {
        NPC_1,
        NPC_2,
    }

    public enum Speaker
    {
        PLAYER,
        ENEMY
    }


    [System.Serializable]
    public class Data
    {
        public Dictionary<string, List<string>> dialogue;
    }

    [System.Serializable]
    public class DataWrapper
    {
        public Dictionary<string, Data[]> allData;
    }
    void Awake()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Dialogue");
        if (jsonFile != null)
        {
            DataWrapper dataWrapper = JsonUtility.FromJson<DataWrapper>(jsonFile.text);
            Debug.Log("??? : " + dataWrapper);
        }
        else
        {
            Debug.LogError("Failed to locate the JSON file in the Resources folder!");
        }
    }
}


