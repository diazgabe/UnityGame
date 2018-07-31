using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turn {
    private Player player;
    private List<BaseUnit> unit;

    public Turn () { 

    }

    public Player getPlayer() {
        return player;
    }

    public List<BaseUnit> getUnit() {
        return unit;
    }
}