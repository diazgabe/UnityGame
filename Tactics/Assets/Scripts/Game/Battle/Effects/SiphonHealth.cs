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
        List<BaseUnit> targets = Map.getUnitAtPosition(position);
        foreach ( BaseUnit target of targets ) {
            target.takeDamage(this.Amount);
            user.heal(this.Amount);
        }
    }
}
