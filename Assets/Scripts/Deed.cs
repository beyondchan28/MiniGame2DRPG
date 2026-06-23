using UnityEngine;

public enum State
{
    NONE,
    CHAT,
    FIGHT,
}

public class Deed : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;

    protected State currentState;

    public void Execute()
    {
        currentState = characterData.stateOrder[0];
        Init();

        WhenExecute();

        // Exit();

    }

    protected virtual void Init() { }

    protected virtual void WhenExecute() { }

    protected virtual void Exit() { }
}
