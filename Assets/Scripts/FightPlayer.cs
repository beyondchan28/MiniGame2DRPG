using UnityEngine;

public class FightPlayer : Fight
{
    [SerializeField] private GameObject actionButtonsContainer;

    private TurnBasedManager turnBasedManager;

    void Awake()
    {
        turnBasedManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<TurnBasedManager>();
        HideActionButtons();
    }

    public override void Attacking()
    {
        Debug.Log("Attacking");
        TurnDone();
    }

    public override void Defending()
    {
        Debug.Log("Defending");
        TurnDone();
    }

    public override void Dodging()
    {
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
