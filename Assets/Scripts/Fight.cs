using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;
    protected TurnBasedManager turnBasedManager;

    void Awake()
    {
        turnBasedManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<TurnBasedManager>();
        OnAwake();
    }

    protected virtual void OnAwake() { }

    public virtual void TurnBegin() { }

    public virtual void TurnDone() { }

    public virtual void Attacking() { }

    public virtual void Defending() { }

    public virtual void Dodging() { }

    public CharacterData GetCharacterData()
    {
        return characterData;
    }
}
