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

    public float GetHP()
    {
        return _currentHealthPoints;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyTroop>() && !_troopsInRange.Contains(other.gameObject))
        {
            _troopsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyTroop>() && _troopsInRange.Contains(other.gameObject))
        {
            _troopsInRange.Remove(other.gameObject);
        }
    }
}
