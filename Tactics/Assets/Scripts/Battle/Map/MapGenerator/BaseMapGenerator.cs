//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//public class BaseMapGenerator: MonoBehaviour, IMapGenerator {

//    protected float gap = 0.05f;
//    protected GameObject landTile;
//    protected Vector3 tileDimensions;
//    protected Transform Map;
//    protected Vector3Int _mapDimensions;
//    protected IMap _Map;

//    public virtual void Awake() {
        
//        tileDimensions = new Vector3(landTile.GetComponent<Renderer>().bounds.size.x, landTile.GetComponent<Renderer>().bounds.size.y, landTile.GetComponent<Renderer>().bounds.size.z);
//    }

//    public IMap generateMap() {
//        Map = new GameObject("Map").transform;
//        return _Map;
//    }

//    public void spawnCube(TileType tileType, Vector3 tilePosition) {

//        GameObject newTile = Instantiate(landTile, tilePosition, Quaternion.identity);
//        _Map.setTile(new Vector3Int(i, j, 0), newTile.GetComponent<ITile>());
//        newTile.name = i + "," + j;
//        newTile.transform.parent = x;
//    }

//    public void fromJson(string filePath) {
//        if (File.Exists(filePath)) {
//            string dataAsJson = File.ReadAllText(filePath);
//        } else {
//            //JsonUtility.From
//        }
//    }

//    public Map createMapFromJson(string json) {

//        Map map = new Map();
//        return null;
//    }
//}

///*
// public class LandMapGenerator : BaseMapGenerator {

//    public LandMapGenerator(Vector3Int mapDimensions) {
//        _mapDimensions = mapDimensions;
//    }
    
//    public override IMap generateMap() {
//        Map map = new Map(this._mapDimensions);
    
//        for (int i = 0; i < _mapDimensions.x; i++) {
//            Transform x = new GameObject("X" + i).transform;
//            x.parent = Map;
//            for (int j = 0; j < _mapDimensions.y; j++) {
//                Vector3 tilePosition = new Vector3(i * (tileDimensions.x + gap), 0, j * (tileDimensions.y + gap));
//                spawnCube(TileType.Land, tilePosition);
//            }
//        }

//        return map;
//    }

//}
//*/
