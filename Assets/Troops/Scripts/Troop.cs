using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Troop : TroopStateMachine
{
    [SerializeField] private string Name;
    [SerializeField] private int HealthPoints;
    [SerializeField] private int AttackDamage;
    [SerializeField] private int Defence;
    [SerializeField] private int MoveSpeed;

    public virtual void InitializeTroop() {}
}
