using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject _currentSelected;

    void OnEnable()
    {
        InputManager.SelectUnit += SelectUnit;
        InputManager.UnSelectUnit += UnSelectUnit;
        InputManager.MoveTroop += MoveTroop;
    }

    void OnDisable()
    {
        InputManager.SelectUnit -= SelectUnit;
        InputManager.UnSelectUnit -= UnSelectUnit;
        InputManager.MoveTroop -= MoveTroop;
    }

    void UnSelectUnit()
    {
        _currentSelected = null;
    }

    void SelectUnit(GameObject target)
    {
        _currentSelected = target;
    }

    void MoveTroop(Vector3 position)
    {
        if (_currentSelected && _currentSelected.CompareTag("Ally_Troop"))
        {
            //move troop to location
            _currentSelected.GetComponent<AllyTroop>().MoveToPosition(position);
        }
    }
}
