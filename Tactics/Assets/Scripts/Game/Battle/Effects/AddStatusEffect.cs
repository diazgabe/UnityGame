using System.Collections.Generic;
using UnityEngine;

public class AddStatusEffect : BaseEffect {

    //private StatusEffect effect;

    public override void execute( Vector3Int position ) {
        List<BaseUnit> targets = Map.getUnitsAtPosition(position);

        foreach ( BaseUnit target in targets ) {
            //target.applyEffect(effect);
        }
    }
}