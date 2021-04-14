using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _hp;
    [SerializeField] private GameObject _spawnTroopButton;

    void OnEnable()
    {
        GameManager.ShowUnitOnUI += SelectUnit;
        GameManager.ResetUI += UnSelectUnit;
    }

    void OnDisable()
    {
        GameManager.ShowUnitOnUI -= SelectUnit;
        GameManager.ResetUI -= UnSelectUnit;
    }

    void SelectUnit(GameObject target)
    {
        var temp = target.GetComponent<ISelectableUnit>();

        _name.text = temp.GetName();
        _hp.text = temp.GetHP().ToString();

        if (target.GetComponent<Building>())
        {
            _spawnTroopButton.SetActive(true);
        } else
        {
            _spawnTroopButton.SetActive(false);
        }
    }

    void UnSelectUnit()
    {
        _name.text = "";
        _hp.text = "";
        _spawnTroopButton.SetActive(false);
    }
}
