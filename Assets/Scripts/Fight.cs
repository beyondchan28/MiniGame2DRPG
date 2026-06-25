using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;

    public virtual void Attacking() { }

    public virtual void Defending() { }

    public virtual void Dodging() { }
}
