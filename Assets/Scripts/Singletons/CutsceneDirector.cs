using UnityEngine;
using System.Collections;

public class CutsceneDirector : MonoBehaviour
{
    public static CutsceneDirector Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
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
