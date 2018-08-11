using UnityEngine;
using System.Collections;

public interface IMoveAbility {
    //bool canExecute(ITile from, ITile to, int moveRange);
    //void execute();

    bool canPassThrough( ITile tile );
    bool canEndTurnOn( ITile tile );
}
