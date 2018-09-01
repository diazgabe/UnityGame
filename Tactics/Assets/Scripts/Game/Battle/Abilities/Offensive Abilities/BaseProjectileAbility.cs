using System.Collections.Generic;
using UnityEngine;

public class BaseProjectileAbility : BaseAbility {

    private int Damage { get; set; }
    private int Range { get; set; }

    public BaseProjectileAbility( int damage, int range ) {
        this.Damage = damage;
        this.Range = range;
    }

    public bool canExecute( Vector3Int position ) {
        return true;
    }

    public void execute( Vector3Int position ) {
        if ( !this.canExecute( position ) ) {
            return;
        }

        List<BaseUnit> targets = Map.getUnitsAtPosition( position );
        foreach ( BaseUnit target in targets ) {
            target.takeDamage( this.Damage );
        }

        foreach ( BaseEffect effect in this.Effects ) {
            effect.execute( position );
        }
    }

}
