using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMapGenerator : MapGenerator {

    GameObject landTile = Resources.Load<GameObject>("Prefabs/LandTile Prefab");
    
    float gap = 0.05f;

    public LandMapGenerator(Vector2Int mapDimensions) {
        _mapDimensions = mapDimensions;
    }


    public override IMap generateMap() {
        
        _map = new LandTile[_mapDimensions.x, _mapDimensions.y];
        Vector2 tileDim = new Vector2(landTile.GetComponent<Renderer>().bounds.size.x, landTile.GetComponent<Renderer>().bounds.size.z);

        Transform Map = new GameObject("Map").transform;
        for (int i = 0; i < _mapDimensions.x; i++) {

            Transform x = new GameObject("X" + i).transform;
            x.parent = Map;
            for (int j = 0; j < _mapDimensions.y; j++) {

                Vector3 tilePosition = new Vector3(i * (tileDim.x + gap), 0, j * (tileDim.y + gap));

                GameObject newTile = null;

                _map[i, j] = new LandTile();
                newTile = GameObject.Instantiate(landTile, tilePosition, Quaternion.identity);

                newTile.name = i + "," + j;
                newTile.transform.parent = x;
            }
        }

        return null;
    }

}
