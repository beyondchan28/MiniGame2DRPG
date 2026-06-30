using UnityEngine;
using System.Collections;

public class CutsceneDirector : MonoBehaviour
{
    public static CutsceneDirector Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // Destroy(gameObject);
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void StartCutscene()
    {
        StartCoroutine(CutsceneOne());
    }

    IEnumerator CutsceneOne()
    {
        Debug.Log("[INFO] Cutscene one BEGIN");

        yield return new WaitUntil(() => DialogueManager.Instance.IsDialogueDone());

        Debug.Log("[INFO] Cutscene one END");

    }
}
