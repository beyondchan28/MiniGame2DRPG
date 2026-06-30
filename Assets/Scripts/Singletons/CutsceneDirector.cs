using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CutsceneDirector : MonoBehaviour
{
    public static CutsceneDirector Instance;

    private Dictionary<string, Func<IEnumerator>> cutscenes;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        cutscenes = new Dictionary<string, Func<IEnumerator>>() {
            {"CutsceneOne", CutsceneOne}
        };

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void StartCutscene(string cutsceneName)
    {
        StartCoroutine(cutscenes[cutsceneName].Invoke());
    }

    IEnumerator CutsceneOne()
    {
        Debug.Log("[INFO] Cutscene one BEGIN");

        yield return new WaitUntil(() => DialogueManager.Instance.IsDialogueDone());

        Debug.Log("[INFO] Cutscene one END");

    }
}
