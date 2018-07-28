using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType {
    Land,
    Water,
    Lava
}

public abstract class BaseTile : MonoBehaviour, ITile, IConfigurable {

    protected TileType tileType;
    public bool IsOccupied { get; set; }
    public Vector3Int Index { get; }

    public virtual void Awake() {
        IsOccupied = false;
    }

    public virtual void Start() {

    }

    public virtual void Update() {
        
    }

    public virtual void configure(IConfig config) {

    }
}