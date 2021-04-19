using UnityEngine;

public class Building : MonoBehaviour, ISelectableUnit
{
    [SerializeField] private string Name;
    [SerializeField] private float HealthPoints;
    [SerializeField] private int Defence;

    public string GetName()
    {
        return Name;
    }

    public float GetHP()
    {
        return HealthPoints;
    }
}
