using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

using DialogueData = System.Collections.Generic.Dictionary<
    Session,
    System.Collections.Generic.List<
        System.Collections.Generic.Dictionary<
            Speaker,
            System.Collections.Generic.List<string>
        >
    >
>;

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

public class DialogueManager : MonoBehaviour
{

    private DialogueData dialogueData;

    void Awake()
    {
        LoadDialogueData();
    }

    private void LoadDialogueData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Dialogue");
        if (jsonFile != null)
        {
            dialogueData = JsonConvert.DeserializeObject<DialogueData>(jsonFile.text);
            Debug.Log("??? : " + dialogueData[Session.NPC_1][0][Speaker.PLAYER][0]);

            Debug.Log("[INFO] Dialgoue data succesfully loaded");
        }
        else
        {
            Debug.LogError("Failed to locate the JSON file in the Resources folder!");
        }
    }

}


