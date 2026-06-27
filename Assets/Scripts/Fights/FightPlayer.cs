using UnityEngine;

public class FightPlayer : Fight
{
    [SerializeField] private GameObject actionButtonsContainer;

    protected override void OnAwake()
    {
        HideActionButtons();
    }

    public override void Attacking()
    {
        Debug.Log("Attacking");
        fightJuice.AttackAnimation();
        TurnDone();
    }

    public override void Defending()
    {
        fightJuice.DefendAnimation();
        Debug.Log("Defending");
        TurnDone();
    }

    public override void Dodging()
    {
        fightJuice.DodgeAnimation();
        Debug.Log("Dodging");
        TurnDone();
    }

    public override void TurnBegin()
    {
        ShowActionButtons();
    }

    public override void TurnDone()
    {
        HideActionButtons();
        turnBasedManager.Play();
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
