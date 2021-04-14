using System.Collections.Generic;
using UnityEngine;

public class EnemyTroop : Troop
{
    [HideInInspector]
    public int nextPatrolPointIndex;
    public List<GameObject> PatrolPoints { get { return _patrolPoints; } private set { _patrolPoints = value; } }

    [SerializeField]
    private List<GameObject> _patrolPoints = new List<GameObject>();

    void Start()
    {
        nextPatrolPointIndex = 0;
        ChangeState(new Patrol(this));
    }

    void Update()
    {
        UpdateState();
    }

    //TODO: add on trigger enter event to detect troops and change state to attack
}
