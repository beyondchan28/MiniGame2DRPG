using UnityEngine;
using System.Collections.Generic;

public class FightEnemy : Fight
{
    private List<FightPlayer> targets = new List<FightPlayer>();
    int targetIndex = 0;

    protected override void OnAwake()
    {
        foreach (var go in GameObject.FindGameObjectsWithTag("Player"))
        {
            targets.Add(go.GetComponent<FightPlayer>());
        }
    }

    public override void Attacking()
    {
        targets[targetIndex].Damaged(fightData.Attack);
        base.Attacking();
    }

    public override void Defending()
    {
        base.Defending();
    }

    public override void Dodging()
    {
        base.Dodging();
    }

    void ChooseAction()
    {
        int randomVal = UnityEngine.Random.Range(0, 3);
        switch (randomVal)
        {
            case 0:
                Attacking();
                break;
            case 1:
                Defending();
                break;
            case 2:
                Dodging();
                break;
        }
    }

    public override void TurnBegin()
    {
        ChooseAction();
    }

    public override void TurnDone()
    {
        turnBasedManager.FindTurn();
    }
}
