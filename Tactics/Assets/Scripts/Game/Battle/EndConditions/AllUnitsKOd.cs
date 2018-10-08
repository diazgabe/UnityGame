using System.Collections.Generic;

public class AllUnitsKOd : EndCondition {

    public IReadOnlyList<BaseUnit> units;

    public AllUnitsKOd( IReadOnlyList<BaseUnit> units ) {
        this.units = units;
    }

    public override bool check() {
        foreach ( BaseUnit unit in this.units ) {
            if ( !unit.isKOd ) {
                return false;
            }
        }

        return true;
    }

    public override void trigger() {
        throw new System.NotImplementedException();
    }
}