using UnityEngine;
using System.Collections.Generic;

public class FightPlayer : Fight
{
    [SerializeField] private GameObject actionButtonsContainer;

    private List<FightEnemy> targets = new List<FightEnemy>();
    int targetIndex = 0;

    protected override void OnAwake()
    {
        HideActionButtons();
        foreach (var go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            targets.Add(go.GetComponent<FightEnemy>());
        }
    }

    public override void Attacking()
    {
        Debug.Log("Attacking");
        fightJuice.AttackAnimation();
        targets[targetIndex].Damaged(characterData.Attack);
        base.Attacking();
    }

    public override void Defending()
    {
        fightJuice.DefendAnimation();
        Debug.Log("Defending");
        base.Defending();
    }

    public override void Dodging()
    {
        fightJuice.DodgeAnimation();
        base.Dodging();
    }

    public override void TurnBegin()
    {
        ShowActionButtons();
    }

    public override void TurnDone()
    {
        HideActionButtons();
        turnBasedManager.FindTurn();
    }

    void ShowActionButtons()
    {
        actionButtonsContainer.SetActive(true);
    }

    void HideActionButtons()
    {
        actionButtonsContainer.SetActive(false);
    }
}
