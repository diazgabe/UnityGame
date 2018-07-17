using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMapGenerator : BaseMapGenerator {

    GameObject landTile = Resources.Load<GameObject>("Prefabs/LandTile Prefab");
    
    float gap = 0.05f;

    public LandMapGenerator(Vector3Int mapDimensions) {
        _mapDimensions = mapDimensions;
    }


    public override IMap generateMap() {

        Map map = new Map(this._mapDimensions);

        Vector2 tileDim = new Vector2(landTile.GetComponent<Renderer>().bounds.size.x, landTile.GetComponent<Renderer>().bounds.size.z);

        Transform Map = new GameObject("Map").transform;
        for (int i = 0; i < _mapDimensions.x; i++) {

            Transform x = new GameObject("X" + i).transform;
            x.parent = Map;
            for (int j = 0; j < _mapDimensions.y; j++) {
                map.setTile(new Vector3Int(i, j, 0), new LandTile());

                Vector3 tilePosition = new Vector3(i * (tileDim.x + gap), 0, j * (tileDim.y + gap));
                GameObject newTile = Instantiate(landTile, tilePosition, Quaternion.identity);
                newTile.name = i + "," + j;
                newTile.transform.parent = x;
            }
        }

        return map;
    }

}
