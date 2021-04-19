using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCollider : MonoBehaviour
{
    private GameObject _parentGameObject;
    private string _tag;

    private void OnEnable()
    {
        _parentGameObject = transform.parent.gameObject;

        if (_parentGameObject.CompareTag("Enemy_Troop"))
        {
            _tag = "Ally_Troop";
        } else
        {
            _tag = "Enemy_Troop";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if colliding with enemy action collider change to combat state
        if (other.gameObject.CompareTag("Action_Collider") && other.transform.parent.gameObject.CompareTag(_tag))
        {
            Troop _thisTroop = _parentGameObject.GetComponent<Troop>();
            _thisTroop.currentTarget = other.transform.parent.gameObject.GetComponent<Troop>();
            _thisTroop.ChangeState(new Combat(_thisTroop));
        }
    }
}
