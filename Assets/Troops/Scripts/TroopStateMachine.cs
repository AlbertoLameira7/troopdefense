using UnityEngine;

public class TroopStateMachine : MonoBehaviour
{
    protected TroopState troopState;
    protected TroopState previousTroopState;

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
