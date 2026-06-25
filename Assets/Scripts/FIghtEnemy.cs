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
}
