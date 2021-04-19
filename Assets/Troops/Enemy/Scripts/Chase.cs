﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : TroopState
{
    public Chase(Troop entity) : base(entity)
    {
    }

    public override void Enter()
    {
        var newEnt = (EnemyTroop)Entity; //Temporary solution, only enemies can patrol for now
        newEnt.NavMeshAgentComponent.destination = newEnt._troopsInRange[0].transform.position;
    }

    public override void Execute()
    {
        // update with new target pos
        var newEnt = (EnemyTroop)Entity; //Temporary solution, only enemies can patrol for now
        newEnt.NavMeshAgentComponent.destination = newEnt._troopsInRange[0].transform.position;

        // check if close enough, stop and change state to attack
        if (!Entity.NavMeshAgentComponent.pathPending)
        {
            if (Entity.NavMeshAgentComponent.remainingDistance <= Entity.NavMeshAgentComponent.stoppingDistance)
            {
                if (!Entity.NavMeshAgentComponent.hasPath || Entity.NavMeshAgentComponent.velocity.sqrMagnitude == 0f)
                {
                    Entity.ChangeState(new Patrol(Entity));
                }
            }
        }
    }

    public override void Exit()
    {
        //var newEnt = (EnemyTroop)Entity; //Temporary solution, only enemies can patrol for now

    }
}
