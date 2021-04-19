using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action<GameObject> ShowUnitOnUI;
    public static Action ResetUI;
    public static Action<GameObject> RemoveTroopFromInRange;

    [SerializeField] private Vector3 _position = Vector3.zero;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _maxTroopCount = 5;
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private GameObject _winScreen;
    private GameObject _currentSelected;
    private List<GameObject> _troops;

    public void ClickedSpawnButton()
    {
        if (_troops.Count < _maxTroopCount)
        {
            _troops.Add(SpawnTroopAtLocation(_position));
        }
    }

    GameObject SpawnTroopAtLocation(Vector3 position)
    {
        return Instantiate(_prefab, position, Quaternion.identity);
    }

    void Awake()
    {
        _troops = new List<GameObject>();
    }

    void OnEnable()
    {
        InputManager.SelectUnit += SelectUnit;
        InputManager.UnSelectUnit += UnSelectUnit;
        InputManager.MoveTroop += MoveTroop;
        Troop.RemoveTroopFromGame += RemoveTroopFromGame;
    }

    void OnDisable()
    {
        InputManager.SelectUnit -= SelectUnit;
        InputManager.UnSelectUnit -= UnSelectUnit;
        InputManager.MoveTroop -= MoveTroop;
        Troop.RemoveTroopFromGame -= RemoveTroopFromGame;
    }

    void UnSelectUnit()
    {
        _currentSelected = null;
        ResetUI();
    }

    void SelectUnit(GameObject target)
    {
        _currentSelected = target;
        ShowUnitOnUI(target);
    }

    void MoveTroop(Vector3 position)
    {
        if (_currentSelected && _currentSelected.CompareTag("Ally_Troop"))
        {
            //move troop to location
            _currentSelected.GetComponent<AllyTroop>().MoveToPosition(position);
        }
    }

    void RemoveTroopFromGame(GameObject troop)
    {
        RemoveTroopFromInRange(troop);

        if (troop.GetComponent<EnemyTroop>())
        {
            _enemies.Remove(troop);

            if (_enemies.Count <= 0)
            {
                GameOver();
            }
        }

        Destroy(troop);
    }

    void GameOver()
    {
        _winScreen.SetActive(true);
    }
}
