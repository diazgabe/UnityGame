using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMapGenerator: MonoBehaviour, IMapGenerator {

    protected Vector3Int _mapDimensions;
    protected IMap _Map;

    public abstract IMap generateMap();

}
