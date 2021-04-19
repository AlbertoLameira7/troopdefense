using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public abstract class Troop : TroopStateMachine, Damageable
{
    public NavMeshAgent NavMeshAgentComponent { get; protected set; }
    public static Action<float> DamageUnit;

    [SerializeField] protected string Name;
    [SerializeField] protected float MaxHealthPoints;
    [SerializeField] protected int AttackDamage;
    [SerializeField] protected int Defence;

    protected float _currentHealthPoints;

    public List<GameObject> _troopsInRange;

    void Awake()
    {
        NavMeshAgentComponent = gameObject.GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        _currentHealthPoints = MaxHealthPoints;
    }

    public void TakeDamage(int damageValue)
    {
        _currentHealthPoints -= damageValue;
        var healthPercentage = ((_currentHealthPoints - 0) / (MaxHealthPoints - 0)) * 100;
        DamageUnit(healthPercentage);

        if (_currentHealthPoints <= 0)
        {
            // send event to gameManager to destroy this object
            Destroy(gameObject); //temporary solution
        }
    }
}
