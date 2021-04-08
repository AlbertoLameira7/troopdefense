using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TroopState
{
    /*protected PlayerController Entity;

    public PlayerState(PlayerController entity)
    {
        Entity = entity;
    }*/

    public virtual void Enter() {}

    public virtual void Execute() {}

    public virtual void Exit() {}
}
