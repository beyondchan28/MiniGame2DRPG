using UnityEngine;
using TMPro;

public class DialogueBubble : MonoBehaviour
{
    [SerializeField] private TextMeshPro speaker;
    [SerializeField] private TextMeshPro chat;

    public void SetChatBubble(string speakerTxt, string chatTxt)
    {
        speaker.text = speakerTxt;
        chat.text = chatTxt;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
