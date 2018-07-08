using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour, IUnit {

    public string Name { get; set; }
    public int MoveRange { get; }
    public Vector3 Coord { get; set; }

    public void move(ITile tile) {
        if (canMoveTo(tile)) {
            Debug.Log(this.name);
        }
    }

    protected bool canMoveTo(ITile tile) {
        return false;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
