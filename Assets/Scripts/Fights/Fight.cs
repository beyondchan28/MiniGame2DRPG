using UnityEngine;

public class Fight : MonoBehaviour
{
    public enum State
    {
        NONE,
        ATTACK,
        DEFEND,
        DODGE
    }

    [SerializeField] protected CharacterData characterData;
    [SerializeField] protected FightJuice fightJuice;
    protected TurnBasedManager turnBasedManager;

    protected float healthPoint = 0f;
    protected bool isDead = false;
    protected State currentState = State.NONE;

    void Awake()
    {
        turnBasedManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<TurnBasedManager>();
        OnAwake();
        healthPoint = characterData.Health;
    }

    protected virtual void OnAwake() { }

    public virtual void TurnBegin() { }

    public virtual void TurnDone() { }

    public virtual void Attacking()
    {
        ChangeState(State.ATTACK);
        fightJuice.AttackAnimation();
        TurnDone();
    }

    public virtual void Defending()
    {
        ChangeState(State.DEFEND);
        fightJuice.DefendAnimation();
        TurnDone();
    }

    public virtual void Dodging()
    {
        ChangeState(State.DODGE);
        fightJuice.DodgeAnimation();
        TurnDone();
    }

    public CharacterData GetCharacterData()
    {
        return characterData;
    }

    public void Damaged(float damage)
    {
        switch (currentState)
        {
            case State.DEFEND:
                currentState = State.NONE;
                Damaging(damage - characterData.Defense);
                break;
            case State.DODGE:
                int randomChance = UnityEngine.Random.Range(0, 2);
                currentState = State.NONE;
                if (randomChance == 1)
                {
                    Damaging(damage);
                }
                else
                {
                    Debug.Log("[INFO] Damage is dodged");
                }
                break;
            default:
                Damaging(damage);
                break;
        }
    }

    protected void ChangeState(State newState)
    {
        currentState = newState;
    }

    void Damaging(float realDamage)
    {
        if (realDamage <= 0) return;
        Debug.Log("[INFO] Health before damaged : " + healthPoint);

        healthPoint -= realDamage;
        Debug.Log("[INFO] Health after damaged : " + healthPoint);
        if (healthPoint <= 0)
        {
            isDead = true;
            if (this is FightPlayer) turnBasedManager.DecreasePlayerAmount();
            else turnBasedManager.DecreaseEnemyAmount();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
