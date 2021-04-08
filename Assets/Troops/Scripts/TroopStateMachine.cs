using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopStateMachine : MonoBehaviour
{
    protected TroopState troopState;

    public void ChangeState(TroopState state)
    {
        if (troopState != null)
        {
            troopState.Exit();
        }

        troopState = state;
        troopState.Enter();
    }

    public void UpdateState()
    {
        troopState.Execute();
    }
}
