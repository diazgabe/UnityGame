using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : BaseTile {

    public override void Awake() {
        base.Awake();
        this.tileType = TileType.Water;
    }

    public override void Start() {
        base.Start();
    }

}