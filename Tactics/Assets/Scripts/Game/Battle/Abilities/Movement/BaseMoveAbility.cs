using UnityEngine;

public abstract class BaseMoveAbility : MonoBehaviour, IMoveAbility {

    protected BaseUnit user;
    protected int range;

    public BaseMoveAbility( BaseUnit user, int range ) {
        this.user = user;
        this.range = range;
    }

    public virtual bool canExecute( BaseTile targetDestination ) {
        return Map.containsIndex( targetDestination.Index );
    }

    public abstract void execute( BaseTile targetDestination );

}