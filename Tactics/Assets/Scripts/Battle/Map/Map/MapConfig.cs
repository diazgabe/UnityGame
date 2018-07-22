using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapConfig : IConfig {

    public Vector3Int dimensions;
    public TileConfig[] tiles;

}