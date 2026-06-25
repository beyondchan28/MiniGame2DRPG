using UnityEngine;
using System.Collections.Generic;

public class TurnBasedManager : MonoBehaviour
{
    // setup player and enemy/enemies positions
    // start process agility to determine who's turn
    // On player, after choose action, there is a mini game to determine its multiplier on attack/damage, defend, or dodge

    const float VERTICAL_CHARACTER_SPACING = 30f;
    const float TURN_VISUAL_BASE_SPEED = 100f;

    [SerializeField] private GameObject playerVisual;
    [SerializeField] private GameObject enemyVisual;
    [SerializeField] private GameObject line;

    private List<Fight> fights = new List<Fight>();
    private List<RectTransform> turnVisualRT = new List<RectTransform>();

    private float finishPoint;
    private int currentIdxTurn = 0;

    void Awake()
    {
        SetupFights();
        SetupTurnVisual();
        finishPoint = -line.GetComponent<RectTransform>().rect.width;
    }

    void SetupFights()
    {
        if (fights.Count != 0) fights.Clear();

        foreach (var go in GameObject.FindGameObjectsWithTag("Player"))
        {
            fights.Add(go.GetComponent<Fight>());
        }
        foreach (var go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            fights.Add(go.GetComponent<Fight>());
        }
    }

    void SetupTurnVisual()
    {
        if (turnVisualRT.Count != 0) turnVisualRT.Clear();

        int playerCount = 1;
        int enemyCount = 1;
        foreach (var f in fights)
        {
            if (f is FightPlayer)
            {
                SpawnCharacterTurnVisual(playerVisual, playerCount);
                playerCount += 1;
            }
            else
            {
                SpawnCharacterTurnVisual(enemyVisual, -enemyCount);
                enemyCount += 1;
            }
        }
    }

    void SpawnCharacterTurnVisual(GameObject visual, int fightCount)
    {
        GameObject spawned = Instantiate(visual, line.transform);
        RectTransform rt = spawned.GetComponent<RectTransform>();
        Vector3 currentPos = rt.anchoredPosition;
        currentPos.y = VERTICAL_CHARACTER_SPACING * fightCount;
        rt.anchoredPosition = currentPos;
        turnVisualRT.Add(rt);
    }

    void Update()
    {
        for (int idx = 0; idx < fights.Count; idx += 1)
        {
            Fight f = fights[idx];
            RectTransform rt = turnVisualRT[idx];

            Vector3 currentPos = rt.anchoredPosition;
            currentPos.x -= f.GetCharacterData().Agility * TURN_VISUAL_BASE_SPEED * Time.deltaTime;
            rt.anchoredPosition = currentPos;

            if (rt.anchoredPosition.x <= finishPoint)
            {
                Stop(idx, f);
            }
        }
    }

    public void Play()
    {
        turnVisualRT[currentIdxTurn].anchoredPosition = Vector3.zero;
        enabled = true;
    }

    void Stop(int idx, Fight f)
    {
        currentIdxTurn = idx;
        f.TurnBegin();
        enabled = false;
    }

}
