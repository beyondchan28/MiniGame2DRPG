using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;

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
