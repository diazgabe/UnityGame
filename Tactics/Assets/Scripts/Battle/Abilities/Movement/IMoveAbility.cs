using UnityEngine;
using System.Collections;

public interface IMoveAbility {
    bool canExecute(ITile from, ITile to, int moveRange);
    void execute();
}
