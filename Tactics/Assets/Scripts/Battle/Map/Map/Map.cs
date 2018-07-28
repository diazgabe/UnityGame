using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IMap, IConfigurable {
    private Vector3Int _dimensions;
    private GameObject[,,] _map;
    private GameObject landTile;
    private GameObject lavaTile;
    private GameObject waterTile;
    private Vector3 tileGap = new Vector3(0.05f, 0, 0.05f);
    private Vector3 tileDimensions;
    private Vector3 tileOffset;

    public static Vector3Int[] directions;

    private void Awake() {
        loadTilePrefabs();
        tileDimensions  = new Vector3(landTile.GetComponent<Renderer>().bounds.size.x, landTile.GetComponent<Renderer>().bounds.size.y, landTile.GetComponent<Renderer>().bounds.size.z);
        tileOffset = tileDimensions + tileGap;
        directions = new Vector3Int[4] {
            new Vector3Int(1, 0, 0),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(0, 0, 1),
            new Vector3Int(0, 0, -1)
        };
    }

    private void Start() {
        HashSet<Vector3Int> indexes = getAccessibleTiles( Vector3Int.zero, 3 );
        Vector3Int[] indeces = new Vector3Int[indexes.Count];
        indexes.CopyTo(indeces);
        foreach ( Vector3Int v in indeces ) {
            Debug.Log( v );
        }
    }

    public Map(Vector3Int dimensions) {
        _dimensions = dimensions;
        _map = new GameObject[_dimensions.x, _dimensions.y, _dimensions.z];
    }

    public void setTile(Vector3Int index, GameObject tile) {
        _map[index.x, index.y, index.z] = tile;
    }
    
    public void configure(IConfig config) {
        MapConfig mapConfig = config as MapConfig;
        _map = new GameObject[mapConfig.dimensions.x, mapConfig.dimensions.y, mapConfig.dimensions.z];
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
            setTile(tileConfig.index, tile);
        }
    }

    private void loadTilePrefabs() {
        landTile = Resources.Load<GameObject>("Prefabs/Tiles/Land");
        lavaTile = Resources.Load<GameObject>("Prefabs/Tiles/Lava");
        waterTile = Resources.Load<GameObject>("Prefabs/Tiles/Water");
    }

    public void placeUnitOnIndex(GameObject unit, Vector3Int index) {
        GameObject tile = _map[index.x, index.y, index.z];
        tile.GetComponent<ITile>().IsOccupied = true;
        Vector3 position = tile.transform.position;
        position.y = 1;
        unit.transform.position = position;
    }

    public void placeUnitOnTile(GameObject unit, GameObject tile) {

    }

    /*
        V0 is functional. Needs to add the following:
        * Checks for whether the index exists.
        * Checks for whether the tile is accessible.
        * Optimizations (dont add to nextQueue if there wont be a next round) (instead of 2 queues, just use a counter to denote when a round is over and save space).
        * Triple / comments.
    */
    public HashSet<Vector3Int> getAccessibleTiles( Vector3Int start, int range ) {
        HashSet<Vector3Int> accessibleTiles = new HashSet<Vector3Int>();
        Queue<Vector3Int> queue = new Queue<Vector3Int>();
        Queue<Vector3Int> nextQueue = new Queue<Vector3Int>();

        nextQueue.Enqueue(start);

        int iterationCount = 0;
        while ( nextQueue.Count > 0 && iterationCount <= range) {

            Debug.Log("Iteration " + iterationCount + ": Moving " + nextQueue.Count + " elements between queues.");
            for (int i = nextQueue.Count; i > 0 ; i-- ) {
                Vector3Int temp = nextQueue.Dequeue();
                queue.Enqueue( temp );
                Debug.Log( "Moved " + temp );
            }
            Debug.Log( "Moving finished." );

            while (queue.Count > 0) {
                Vector3Int v = queue.Dequeue();

                Debug.Log( "Analyzing " + v );

                if ( accessibleTiles.Contains( v ) ) {
                    continue;
                }
                accessibleTiles.Add( v );

                foreach ( Vector3Int direction in directions ) {
                    Vector3Int neo = v + direction;
                    if ( !accessibleTiles.Contains( neo ) ) {
                        nextQueue.Enqueue( neo );
                        Debug.Log( "Enqueued " + neo + "to next iteration.");
                    }
                }
            }

            iterationCount++;
        }

        return accessibleTiles;
    }

    public void AStarSearch() {
        
    }
}

/*
 protected Transform Map = new GameObject("Map").transform;

    for (int i = 0; i < _mapDimensions.x; i++) {
//            Transform x = new GameObject("X" + i).transform;
//            x.parent = Map;
     
     
     newTile.name = i + "," + j;
//        newTile.transform.parent = x;
     
     */
