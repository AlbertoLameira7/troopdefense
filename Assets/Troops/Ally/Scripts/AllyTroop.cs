using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyTroop : Troop
{
    public NavMeshAgent NavMeshAgentComponent { get; private set; }
 
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgentComponent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPosition(Vector3 pos)
    {
        NavMeshAgentComponent.destination = pos;
    }

    //TODO: add on trigger enter event to detect enemies and change state to attack
}
