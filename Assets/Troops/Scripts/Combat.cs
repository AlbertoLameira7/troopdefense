using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : TroopState
{
    public Combat(Troop entity) : base(entity)
    {
    }

    public override void Enter()
    {
        Debug.Log("Start Combat");
    }

    public override void Execute()
    {
        if (Entity.currentTarget != null)
        {
            if (Entity.canAttack)
            {
                Entity.currentTarget.TakeDamage(Entity.GetAttackDamage());
                Entity.WaitForNextAttack();
            }
        } else
        {
            Entity.ChangeToPreviousState();
        }
    }

    public override void Exit()
    {

    }
}
