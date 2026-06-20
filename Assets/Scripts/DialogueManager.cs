using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Newtonsoft.Json;
using System.Collections.Generic;

using DialogueData = System.Collections.Generic.Dictionary<
    Session,
    System.Collections.Generic.List<
        Data
    >
>;

[System.Serializable]
public class Data
{
    public Speaker speaker;
    public List<String> dialogueTexts;
}


public enum Session
{
    NONE,
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
    [SerializeField] private InputActionReference interactInput;
    [SerializeField] private DialogueBubble dialogueBubble;

    private DialogueData dialogueData;

    private int chatIndex = 0;
    private int speakerIndex = 0;
    private List<Data> currentDialogueList;

    void Awake()
    {
        LoadDialogueData();
        dialogueBubble.Hide();
        interactInput.action.performed += OnInteractButtonPressed;
    }

    void OnInteractButtonPressed(InputAction.CallbackContext context)
    {
        if (chatIndex + 1 < currentDialogueList[speakerIndex].dialogueTexts.Count)
        {
            chatIndex += 1;
            SetDialogue();
        }
        else
        {
            if (speakerIndex + 1 < currentDialogueList.Count)
            {
                speakerIndex += 1;
                chatIndex = 0;
                SetDialogue();
            }
            else
            {
                interactInput.action.Disable();
                dialogueBubble.Hide();
            }
        }
    }

    void Start()
    {
        Begin(Session.NPC_1);
    }

    private void LoadDialogueData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Dialogue");
        if (jsonFile != null)
        {
            dialogueData = JsonConvert.DeserializeObject<DialogueData>(jsonFile.text);
            Debug.Log("[INFO] Dialgoue data succesfully loaded");
        }
        else
        {
            Debug.LogError("Failed to locate the JSON file in the Resources folder!");
        }
    }

    public void Begin(Session session)
    {
        speakerIndex = 0;
        chatIndex = 0;
        currentDialogueList = GetDialogueDataList(session);
        SetDialogue();
        interactInput.action.Enable();
        dialogueBubble.Show();
    }

    List<Data> GetDialogueDataList(Session session)
    {
        return dialogueData[session];
    }

    void SetDialogue()
    {
        string chatText = currentDialogueList[speakerIndex].dialogueTexts[chatIndex];
        string speakerToString = currentDialogueList[speakerIndex].speaker.ToString();
        string speakerText = char.ToUpper(speakerToString[0]) + speakerToString.Substring(1).ToLower();
        dialogueBubble.SetChatBubble(speakerText, chatText);
    }
}


