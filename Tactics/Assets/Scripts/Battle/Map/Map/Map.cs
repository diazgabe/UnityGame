using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IMap, IConfigurable {
    private Vector3Int _dimensions;
    private ITile[,,] _map;
    private GameObject landTile;
    private GameObject lavaTile;
    private GameObject waterTile;
    private Vector3 tileGap = new Vector3(0.05f, 0, 0.05f);
    private Vector3 tileDimensions;
    private Vector3 tileOffset;

    private void Awake() {
        loadTilePrefabs();
        tileDimensions  = new Vector3(landTile.GetComponent<Renderer>().bounds.size.x, landTile.GetComponent<Renderer>().bounds.size.y, landTile.GetComponent<Renderer>().bounds.size.z);
        tileOffset = tileDimensions + tileGap;
    }

    public Map(Vector3Int dimensions) {
        _dimensions = dimensions;
        _map = new ITile[_dimensions.x, _dimensions.y, _dimensions.z];
    }

    public void setTile(Vector3Int index, ITile tile) {
        _map[index.x, index.y, index.z] = tile;
    }
    
    public void configure(IConfig config) {
        MapConfig mapConfig = config as MapConfig;
        foreach (TileConfig tileConfig in mapConfig.tiles) {
            GameObject tile;
            Vector3 tilePosition = Vector3.Scale(tileOffset, tileConfig.index);
            switch (tileConfig.tileType) {
                case TileType.Land: {
                        tile = Instantiate(landTile, tilePosition, Quaternion.identity);
                        break;
                    }
                case TileType.Lava: {
                        tile = Instantiate(lavaTile, tilePosition, Quaternion.identity);
                        break;
                    }
                case TileType.Water: {
                        tile = Instantiate(waterTile, tilePosition, Quaternion.identity);
                        break;
                    }
                default: {
                        throw new System.ArgumentException("No tile of type '" + tileConfig.tileType + "' exists.");
                    }
            }
            //setTile(tileConfig.index, tile.GetComponent<ITile>());
        }
    }

    private void loadTilePrefabs() {
        landTile = Resources.Load<GameObject>("Prefabs/Tiles/Land");
        lavaTile = Resources.Load<GameObject>("Prefabs/Tiles/Lava");
        waterTile = Resources.Load<GameObject>("Prefabs/Tiles/Water");
    }
}
