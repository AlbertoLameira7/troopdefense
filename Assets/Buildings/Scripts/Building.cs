using UnityEngine;

public class Building : MonoBehaviour, ISelectableUnit
{
    [SerializeField] private string Name;
    [SerializeField] private int HealthPoints;
    [SerializeField] private int Defence;

    public string GetName()
    {
        return Name;
    }

    public int GetHP()
    {
        return HealthPoints;
    }
}
