using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Effect that applies AoE damage in a certain range.
/// </summary>
public class Exploding : BaseEffect {

    private int Damage { get; }
    private int Range { get; }

    public Exploding(int damage, int range) {
        Damage = damage;
        Range = range;
    }

    public override void execute( Vector3Int position ) {
        List<BaseUnit> targets = Map.getUnitsNearPosition(position, this.Range);

        foreach ( BaseUnit target in targets ) {
            target.takeDamage(this.Damage);
        }
    }
}
