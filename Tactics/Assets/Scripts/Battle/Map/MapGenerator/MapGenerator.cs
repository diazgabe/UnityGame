using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapGenerator: IMapGenerator {

    protected Vector2Int _mapDimensions;
    protected ITile[,] _map;
    protected IMap _newMap;

    public abstract IMap generateMap();

}
