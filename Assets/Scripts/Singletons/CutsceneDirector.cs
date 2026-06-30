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

        StartCutscene("CutsceneOne");
    }

    public void StartCutscene(string cutsceneName)
    {
        StartCoroutine(cutscenes[cutsceneName].Invoke());
    }

    IEnumerator CutsceneOne()
    {
        Debug.Log("[INFO] Cutscene one BEGIN");
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

        PlayerInteract pi = playerGO.GetComponent<PlayerInteract>();
        pi.ChangeState(PlayerInteract.State.CUTSCENE);

        DialogueManager.Instance.Begin(DialogueManager.Chat.INTRO);
        yield return new WaitUntil(() => DialogueManager.Instance.IsDialogueDone());


        Vector3 targetPos = Vector3.zero;
        float duration = 2f;
        yield return StartCoroutine(MoveToPosition(playerGO.transform, targetPos, duration));

        pi.ChangeState(PlayerInteract.State.WALK);
        Debug.Log("[INFO] Cutscene one END");
    }

    IEnumerator MoveToPosition(Transform targetT, Vector3 target, float timeToMove)
    {
        Vector3 startPosition = targetT.position;
        float elapsedTime = 0;

        while (elapsedTime < timeToMove)
        {
            float percentage = elapsedTime / timeToMove;
            targetT.position = Vector3.Lerp(startPosition, target, percentage);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetT.position = target;
    }
}
