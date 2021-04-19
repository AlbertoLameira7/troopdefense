using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public abstract class Troop : TroopStateMachine, Damageable
{
    public NavMeshAgent NavMeshAgentComponent { get; protected set; }
    public Troop currentTarget;
    public bool canAttack;
    public static Action<GameObject> RemoveTroopFromGame;

    [SerializeField] protected string Name;
    [SerializeField] protected float MaxHealthPoints;
    [SerializeField] protected int AttackDamage;
    [SerializeField] protected int Defence;
    [SerializeField] protected float AttackSpeed;

    protected float _currentHealthPoints;
    public List<GameObject> _troopsInRange = new List<GameObject>();

    private HealthBar _healthBar;

    protected virtual void Awake()
    {
        NavMeshAgentComponent = gameObject.GetComponent<NavMeshAgent>();
        _healthBar = transform.Find("HealthBar").gameObject.GetComponent<HealthBar>();
    }

    void OnEnable()
    {
        GameManager.RemoveTroopFromInRange += RemoveTroopFromInRange;
        _currentHealthPoints = MaxHealthPoints;
        canAttack = true;
    }

    void OnDisable()
    {
        GameManager.RemoveTroopFromInRange -= RemoveTroopFromInRange;
    }

    public void TakeDamage(int damageValue)
    {
        _currentHealthPoints -= damageValue;
        var healthPercentage = ((_currentHealthPoints - 0) / (MaxHealthPoints - 0)) * 100;
        _healthBar.UpdateHealthBar(healthPercentage);

        if (_currentHealthPoints <= 0)
        {
            // send event to gameManager to destroy this object
            DestroyTroop();
        }
    }

    void DestroyTroop()
    {
        RemoveTroopFromGame(gameObject);
    }

    void RemoveTroopFromInRange(GameObject troop)
    {
        _troopsInRange.Remove(troop);
    }

    public List<GameObject> GetTroopsInRage()
    {
        return _troopsInRange;
    }

    public GameObject GetFirstTroopInRange()
    {
        return _troopsInRange[0];
    }

    public float GetAttackSpeed()
    {
        return AttackSpeed;
    }

    public int GetAttackDamage()
    {
        return AttackDamage;
    }

    public void WaitForNextAttack()
    {
        canAttack = false;
        StartCoroutine("WaitForAttack");
    }

    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(AttackSpeed);
        canAttack = true;
    }
}
