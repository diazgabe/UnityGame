using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType {
    Land,
    Water,
    Lava
}

public abstract class BaseTile : MonoBehaviour, ITile {

    protected TileType tileType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}