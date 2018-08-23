using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : BaseEffect {

    private int damage;
    private int range;

    public override void execute( Vector3Int position ) {
        List<BaseUnit> units = new List<BaseUnit>(); // = Map.getAllUnitsNearPosition(this.range);
        foreach ( BaseUnit unit in units ) {
            unit.takeDamage(this.damage);
        }
        throw new System.NotImplementedException();
    }
}
