using UnityEngine;

public class FightPlayer : Fight
{
    public override void Attacking()
    {
        Debug.Log("Attacking");
    }

    public override void Defending()
    {
        Debug.Log("Defending");
    }

    public override void Dodging()
    {
        Debug.Log("Dodging");
    }
}
