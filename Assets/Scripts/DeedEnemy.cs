using UnityEngine;

public class DeedEnemy : Deed
{
    protected override void Init()
    {

    }

    protected override void WhenExecute()
    {
        switch (currentState)
        {
            case (State.CHAT):
                break;
            case (State.NONE):
                break;
        }
    }

    protected override void Exit()
    {

    }
}
