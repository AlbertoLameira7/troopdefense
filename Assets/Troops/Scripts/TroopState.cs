
public abstract class TroopState
{
    protected Troop Entity;

    public TroopState(Troop entity)
    {
        Entity = entity;
    }

    public virtual void Enter() {}

    public virtual void Execute() {}

    public virtual void Exit() {}
}
