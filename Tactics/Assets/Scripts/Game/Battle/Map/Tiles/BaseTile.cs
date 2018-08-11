using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType {
    Land,
    Water,
    Lava
}

public abstract class BaseTile : MonoBehaviour, ITile, IConfigurable {

    protected Color color;
    protected TileType tileType;
    public bool IsOccupied { get; set; }
    public Vector3Int Index { get; }

    public virtual void Awake() {
        this.color = GetComponent<Renderer>().material.color;
        this.IsOccupied = false;
    }

    public virtual void Start() {

    }

    public virtual void Update() {
        
    }

    public virtual void configure(IConfig config) {

    }

    public virtual void highlight() {
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    public virtual void unHighlight() {
        this.GetComponent<Renderer>().material.color = this.color;
    }
}