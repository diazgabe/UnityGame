using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType {
    Land,
    Water,
    Lava
}

public abstract class BaseTile : ITile {

    public bool IsOccupied { get; set; }
    public Vector3Int Location { get; }
    protected TileType tileType;

    public BaseTile() {
        IsOccupied = false;
    }

    public void setIsOccupied(bool b) {
        IsOccupied = b;
    }
}