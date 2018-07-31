using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTile : BaseTile {

    public override void Awake() {
        base.Awake();
        this.tileType = TileType.Land;
    }

    public override void Start() {
        base.Start();
    }

}