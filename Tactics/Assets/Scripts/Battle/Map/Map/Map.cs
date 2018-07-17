using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : IMap {
    private ITile[,,] _map;

    public Map(Vector3Int dimensions) {
        _map = new ITile[dimensions.x, dimensions.y, dimensions.z];
    }

    public void setTile(Vector3Int index, ITile tile) {
        _map[index.x, index.y, index.z] = tile;
    }
}
