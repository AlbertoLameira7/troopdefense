using UnityEngine;

public class Patrol : TroopState
{
    public Patrol(Troop entity) : base(entity)
    {
    }

    public override void Enter()
    {
        var newEnt = (EnemyTroop)Entity; //Temporary solution, only enemies can patrol for now
        GameObject nextPatrolPoint = newEnt.PatrolPoints[newEnt.nextPatrolPointIndex];
        Vector3 pos = nextPatrolPoint.transform.position;
        newEnt.NavMeshAgentComponent.destination = pos;
    }

    public override void Execute()
    {
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
        var newEnt = (EnemyTroop)Entity; //Temporary solution, only enemies can patrol for now
        newEnt.nextPatrolPointIndex++;
        if (newEnt.nextPatrolPointIndex >= newEnt.PatrolPoints.Count)
        {
            newEnt.nextPatrolPointIndex = 0;
        }
    }
}
