using UnityEngine;
using TMPro;

public class DialogueBubble : MonoBehaviour
{
    const float Y_POS_OFFSET = 2f;

    [SerializeField] private TextMeshPro speaker;
    [SerializeField] private TextMeshPro chat;
    [SerializeField] private Transform mainCameraT;

    void SetPosition()
    {
        Vector3 showPos = mainCameraT.position;
        showPos.y += Y_POS_OFFSET;
        showPos.z = 0f;
        transform.position = showPos;
    }

    public void SetChatBubble(string speakerTxt, string chatTxt)
    {
        speaker.text = speakerTxt;
        chat.text = chatTxt;
    }

    public void Show()
    {
        SetPosition();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
