using System.Collections.Generic;

public class Turn {
    public Player player { get; }
    public List<BaseUnit> units { get; }

    public Turn (Player player, List<BaseUnit> units) {
        this.player = player;
        this.units = units;
    }

    public Turn( Player player, BaseUnit unit ) {
        this.player = player;
        this.units = new List<BaseUnit>();
        units.Add(unit);
    }
}