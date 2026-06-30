using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Newtonsoft.Json;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public Speaker speaker;
        public List<String> dialogueTexts;
    }

    public enum Chat
    {
        NONE,
        NPC_OPEN_FIGHT,
        NPC_CLOSE_FIGHT,
        OPEN_CHEST,
        CLOSE_CHEST
    }

    public enum Speaker
    {
        NONE,
        PLAYER,
        ENEMY
    }

    public static DialogueManager Instance;

    [SerializeField] private DialogueBubble dialogueBubble;

    private Dictionary<Chat, List<Data>> dialogueData;

    private int chatIndex = 0;
    private int speakerIndex = 0;
    private List<Data> currentDialogueList;

    private bool isDialogueDone = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        LoadDialogueData();
        dialogueBubble.Hide();

        DontDestroyOnLoad(gameObject);
    }

    public void NextDialogue()
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
                dialogueBubble.Hide();
                isDialogueDone = true;
            }
        }
    }

    private void LoadDialogueData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Dialogue");
        if (jsonFile != null)
        {
            dialogueData = JsonConvert.DeserializeObject<Dictionary<Chat, List<Data>>>(jsonFile.text);
            Debug.Log("[INFO] Dialgoue data succesfully loaded");
        }
        else
        {
            Debug.LogError("Failed to locate the JSON file in the Resources folder!");
        }
    }

    public void Begin(Chat chat)
    {
        speakerIndex = 0;
        chatIndex = 0;
        isDialogueDone = false;
        currentDialogueList = GetDialogueDataList(chat);
        SetDialogue();
        CutsceneDirector.Instance.StartCutscene();
        dialogueBubble.Show();
    }

    List<Data> GetDialogueDataList(Chat chat)
    {
        return dialogueData[chat];
    }

    void SetDialogue()
    {
        string chatText = currentDialogueList[speakerIndex].dialogueTexts[chatIndex];
        string speakerToString = currentDialogueList[speakerIndex].speaker.ToString();
        string speakerText = char.ToUpper(speakerToString[0]) + speakerToString.Substring(1).ToLower();
        dialogueBubble.SetChatBubble(speakerText, chatText);
    }
    public bool IsDialogueDone()
    {
        return isDialogueDone;
    }

}


