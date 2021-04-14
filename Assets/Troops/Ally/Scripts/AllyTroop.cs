using UnityEngine;

public class AllyTroop : Troop, ISelectableUnit
{
    //TODO: Change this method to use the state machine
    public void MoveToPosition(Vector3 pos)
    {
        NavMeshAgentComponent.destination = pos;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetHP()
    {
        return HealthPoints;
    }

    //TODO: add on trigger enter event to detect enemies and change state to attack
}
