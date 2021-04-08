using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static Action<GameObject> SelectUnit;
    public static Action UnSelectUnit;
    public static Action<Vector3> MoveTroop;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("Ally_Troop") || hit.collider.gameObject.CompareTag("Building"))
                {
                    // Run subscribed event function from game Manager and set current selected target as the GameObject Hit by raycast
                    SelectUnit(hit.collider.gameObject);
                }
                else
                {
                    // Run subscribed event function from game Manager and remove current selected target
                    UnSelectUnit();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                // Run subscribed event function from game Manager and move troop to clicked location
                MoveTroop(hit.point);
            }
        }
    }
}
