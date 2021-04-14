using UnityEngine;
using UnityEngine.AI;

public abstract class Troop : TroopStateMachine
{
    public NavMeshAgent NavMeshAgentComponent { get; protected set; }

    [SerializeField] protected string Name;
    [SerializeField] protected int HealthPoints;
    [SerializeField] protected int AttackDamage;
    [SerializeField] protected int Defence;

    void Awake()
    {
        NavMeshAgentComponent = gameObject.GetComponent<NavMeshAgent>();
    }
}
