using UnityEngine;

public class FIghtEnemy : Fight
{
    public override void Attacking()
    {
        Debug.Log("Enemy Attacking");
    }

    public override void Defending()
    {
        Debug.Log("Enemy Defending");
    }

    public override void Dodging()
    {
        Debug.Log("Enemy Dodging");
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
        TurnDone();
    }

    public override void TurnBegin()
    {
        ChooseAction();
    }

    public override void TurnDone()
    {
        turnBasedManager.Play();
    }
}
