using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnBasedManager : MonoBehaviour
{
    // setup player and enemy/enemies positions
    // start process agility to determine who's turn
    // On player, after choose action, there is a mini game to determine its multiplier on attack/damage, defend, or dodge

    const float VERTICAL_CHARACTER_SPACING = 30f;
    const float TURN_VISUAL_BASE_SPEED = 300f;

    [SerializeField] private GameObject playerVisual;
    [SerializeField] private GameObject enemyVisual;
    [SerializeField] private GameObject line;

    private List<Fight> fights = new List<Fight>();
    private List<RectTransform> turnVisualRT = new List<RectTransform>();

    private float finishPoint;
    private int currentIdxTurn = 0;

    private int enemyAmount = 0;
    private int playerAmount = 0;

    void Awake()
    {
        SetupFights();
        SetupTurnVisual();
        finishPoint = -line.GetComponent<RectTransform>().rect.width;
    }

    void SetupFights()
    {
        if (fights.Count != 0) fights.Clear();

        enemyAmount = 0;
        playerAmount = 0;

        foreach (var go in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerAmount += 1;
            fights.Add(go.GetComponent<Fight>());
        }
        foreach (var go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyAmount += 1;
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

    void ResizeTurnVisual(RectTransform rt, float size)
    {
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
    }

    void Update()
    {
        for (int idx = 0; idx < fights.Count; idx += 1)
        {
            Fight f = fights[idx];

            if (f.IsDead()) continue;

            RectTransform rt = turnVisualRT[idx];

            Vector3 currentPos = rt.anchoredPosition;
            currentPos.x -= f.GetCharacterData().Agility * (TURN_VISUAL_BASE_SPEED * Time.deltaTime);
            rt.anchoredPosition = currentPos;

            if (rt.anchoredPosition.x <= finishPoint)
            {
                ResizeTurnVisual(rt, 150f);
                StopFindingTurn(idx, f);
                break;
            }
        }
    }

    public void FindTurn()
    {
        if (IsFightEnded()) return;
        Invoke(nameof(DelayFindTurn), 1f);
    }
    void DelayFindTurn()
    {
        RectTransform lastRT = turnVisualRT[currentIdxTurn];
        ResizeTurnVisual(lastRT, 100f);
        lastRT.anchoredPosition = Vector3.zero;
        enabled = true;
    }

    void StopFindingTurn(int idx, Fight f)
    {
        currentIdxTurn = idx;
        f.TurnBegin();
        enabled = false;
    }

    bool IsFightEnded()
    {
        if (enemyAmount == 0 || playerAmount == 0)
        {
            Debug.Log("[INFO] FIGHT ENDED");
            line.gameObject.SetActive(false);
            return true;
        }
        else return false;
    }

    public void DecreasePlayerAmount()
    {
        playerAmount -= 1;
    }

    public void DecreaseEnemyAmount()
    {
        enemyAmount -= 1;
    }

}
