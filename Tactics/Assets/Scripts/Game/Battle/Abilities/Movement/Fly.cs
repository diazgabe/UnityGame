using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : BaseMoveAbility {

    public override bool canEndTurnOn( ITile tile ) {
        return true;
    }

    public override bool canPassThrough( ITile tile ) {
        return true;
    }

}
