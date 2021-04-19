using System.Collections.Generic;
using UnityEngine;

public class EnemyTroop : Troop
{
    [HideInInspector]
    public int nextPatrolPointIndex;
    public List<GameObject> PatrolPoints { get { return _patrolPoints; } private set { _patrolPoints = value; } }

    [SerializeField]
    private List<GameObject> _patrolPoints = new List<GameObject>();
    private bool _isChasing;

    void Start()
    {
        nextPatrolPointIndex = 0;
        ChangeState(new Patrol(this));
    }

    void Update()
    {
        if (_troopsInRange.Count > 0 && !_isChasing)
        {
            _isChasing = true;
            ChangeState(new Chase(this));
        } else if (_troopsInRange.Count <= 0 && _isChasing)
        {
            _isChasing = false;
            ChangeToPreviousState();
        }

        if (Input.GetMouseButtonDown(0))
        {
            //TakeDamage(1);
        }

        UpdateState();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AllyTroop>() && !_troopsInRange.Contains(other.gameObject))
        {
            _troopsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<AllyTroop>() && _troopsInRange.Contains(other.gameObject))
        {
            _troopsInRange.Remove(other.gameObject);
        }
    }
}
