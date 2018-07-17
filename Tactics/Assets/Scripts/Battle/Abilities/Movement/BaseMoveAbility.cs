using UnityEngine;
using System.Collections;

public abstract class BaseMoveAbility : MonoBehaviour, IMoveAbility {

    public abstract bool canExecute(ITile from, ITile to, int moveRange);
    public abstract void execute();
}
