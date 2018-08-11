using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTile : BaseTile {

    public override void Awake() {
        base.Awake();
        this.tileType = TileType.Lava;
    }

    public override void Start() {
        base.Start();
    }

}