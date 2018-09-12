using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiphonHealth : BaseEffect {

	private int Amount;
	private BaseUnit user;

	public SiphonHealth( int amount, BaseUnit user ) {
		this.Amount = amount;
	}

	public override void execute( Vector3Int position ) {
        List<BaseUnit> targets = Map.getUnitsAtPosition(position);
        foreach ( BaseUnit target in targets ) {
            user.heal( target.takeDamage( this.Amount ) );
        }
    }
}
