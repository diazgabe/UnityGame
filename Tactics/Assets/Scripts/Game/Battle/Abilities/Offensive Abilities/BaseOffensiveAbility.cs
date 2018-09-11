using System.Collections.Generic;
using UnityEngine;

public class BaseOffensiveAbility : BaseAbility {

    private int Damage { get; set; }
    private int Range { get; set; }
    private List<Vector3Int> HitArea { get; set; }

    public BaseOffensiveAbility( int damage, int range, List<Vector3Int> hitArea ) {
        this.Damage = damage;
        this.Range = range;
        this.HitArea = hitArea;
    }

    public virtual bool canExecute( Vector3Int position ) {
        return true;
    }

    public virtual void execute( Vector3Int position ) {
        if ( !this.canExecute( position ) ) {
            return;
        }

        List<BaseUnit> targets = new List<BaseUnit>();
        foreach(Vector3Int offset in this.HitArea) {
        	Vector3Int index = offset + position;
        	if (!Map.containsIndex(index)) {
        		continue;
        	}

        	List<BaseUnit> temp = Map.getUnitsAtPosition( index );
        	foreach(BaseUnit unit in temp) {
        		if (!targets.Contains(unit)) {
        			targets.Add(unit);
        		}
        	}
        }

        foreach ( BaseUnit target in targets ) {
	        target.takeDamage( this.Damage );
	    }

	    foreach ( BaseEffect effect in this.Effects ) {
	        effect.execute( position );
	    }
    }
}