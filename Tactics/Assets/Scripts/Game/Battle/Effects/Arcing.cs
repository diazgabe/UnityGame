using System.Collections.Generic;
using UnityEngine;

public class Arcing : BaseEffect {

    private int MaxBounce { get; }
    private int MaxRange { get; }
    private int Damage { get; }

    public Arcing(int maxBounce, int maxRange, int damage) {
        this.MaxBounce = maxBounce;
        this.MaxRange = maxRange;
        this.Damage = damage;
    }

    private List<BaseUnit> logic() {
        List<BaseUnit> alreadyAttackedUnits = new List<BaseUnit>();
        List<BaseUnit> targets = new List<BaseUnit>();
        return targets;

    }

    public override void execute( Vector3Int position ) {
        List<BaseUnit> targets = logic();
        foreach ( BaseUnit target in targets ) {
            target.takeDamage(this.Damage);
        }
    }
}
