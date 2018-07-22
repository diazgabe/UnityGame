using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTile : BaseTile {

    public override void Start() {
        base.Start();
        this.tileType = TileType.Land;
    }

}