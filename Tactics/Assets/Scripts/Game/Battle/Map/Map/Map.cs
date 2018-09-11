using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IMap, IConfigurable {
    private static Map _instance;
    private Vector3Int _dimensions;
    private GameObject[,,] _map;
    private GameObject landTile;
    private GameObject lavaTile;
    private GameObject waterTile;
    private Vector3 tileGap = new Vector3(0.05f, 0, 0.05f);
    private Vector3 tileDimensions;
    private Vector3 tileOffset;

    public static Vector3Int[] directions;

    private HashSet<Vector3Int> highlighted;

    private void Awake() {
        if ( _instance != null && _instance != this ) {
            Destroy( this.gameObject );
        } else {
            _instance = this;
        }

        initialize();
    }

    private void Start() {

    }

    public void configure(IConfig config) {
        MapConfig mapConfig = config as MapConfig;
        this._dimensions = mapConfig.dimensions;
        _map = new GameObject[this._dimensions.x, this._dimensions.y, this._dimensions.z];
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

    private void initialize() {
        loadTilePrefabs();
        tileDimensions = new Vector3( landTile.GetComponent<Renderer>().bounds.size.x, landTile.GetComponent<Renderer>().bounds.size.y, landTile.GetComponent<Renderer>().bounds.size.z );
        tileOffset = tileDimensions + tileGap;
        directions = new Vector3Int[4] {
            new Vector3Int(1, 0, 0),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(0, 0, 1),
            new Vector3Int(0, 0, -1)
        };
    }

    private void loadTilePrefabs() {
        landTile = Resources.Load<GameObject>("Prefabs/Tiles/Land");
        lavaTile = Resources.Load<GameObject>("Prefabs/Tiles/Lava");
        waterTile = Resources.Load<GameObject>("Prefabs/Tiles/Water");
    }

    private void onAttackButtonClick() {
        unHighlightTiles( highlighted );
    }

    private void onMoveButtonClick() {
        highlightTiles( highlighted );
    }

    public void setTile(Vector3Int index, GameObject tile) {
        _map[index.x, index.y, index.z] = tile;
    }
    


    public void placeUnitOnIndex(GameObject unit, Vector3Int index) {
        BaseTile tile = getTile(index);
        tile.IsOccupied = true;
        Vector3 position = tile.transform.position;
        position.y = 1;
        unit.transform.position = position;
    }

    public void placeUnitOnTile(GameObject unit, GameObject tile) {

    }


    private void highlightTiles(HashSet<Vector3Int> tiles) {
        IEnumerator<Vector3Int> enumerator = tiles.GetEnumerator();
        while (enumerator.MoveNext()) {
            ITile tile = getTile(enumerator.Current);
            tile.highlight();
        }
    }

    public static List<BaseUnit> getUnitsAtPosition(Vector3Int position) {
        if (!_instance) {
            return null;
        }

        return _instance.getTile( position ).Occupants;
    }

    public static List<BaseTile> getTilesNearPosition( Vector3Int position, int range ) {
        List<BaseTile> tiles = new List<BaseTile>();

        // Origin
        if ( _instance.containsIndex( position ) ) {
            tiles.Add( _instance.getTile( position ) );
        }
        
        for ( int i = 1; i <= range; i++ ) {
            foreach (Vector3Int direction in directions) {
                Vector3Int possibleIndex = direction * i + position;
                if ( _instance.containsIndex( possibleIndex ) ) {
                    tiles.Add( _instance.getTile( possibleIndex ) );
                }
            }
        }

        return tiles;
    }

    public static List<BaseUnit> getUnitsNearPosition( Vector3Int position, int range ) {
        List<BaseTile> tiles = getTilesNearPosition(position, range);
        List<BaseUnit> units = new List<BaseUnit>();
        foreach ( BaseTile tile in tiles ) {
            units.AddRange(tile.Occupants);
        }
        return units;
    }

    private void unHighlightTiles( HashSet<Vector3Int> tiles ) {
        IEnumerator<Vector3Int> enumerator = tiles.GetEnumerator();
        while ( enumerator.MoveNext() ) {
            ITile tile = getTile(enumerator.Current);
            tile.unHighlight();
        }
    }

    private BaseTile getTile(Vector3Int v) {
        return _map[v.x, v.y, v.z].GetComponent<BaseTile>();
    }

    //Still need to add functionality to determine whether tile is accessible under certain unit conditions.
    /// <summary>
    /// Uses DFS to find all accessible tile indexes in range of start position on map. 
    /// </summary>
    /// <param name="start">Start position.</param>
    /// <param name="range">Range to limit search to.</param>
    /// <returns>Returns hashset containing all accessible tile indexes in range of start position.</returns>
    public HashSet<Vector3Int> getAccessibleTileIndexes( Vector3Int start, int range ) { 

        if ( !this.containsIndex( start ) ) {
            Debug.LogWarning("Index " + start + " is not in map.");
            return null;
        }

        HashSet<Vector3Int> visited = new HashSet<Vector3Int>();
        Stack<Vector3Int> stack = new Stack<Vector3Int>();

        stack.Push( start );

        while ( stack.Count > 0 ) {
            Vector3Int current = stack.Pop();

            if ( visited.Contains( current ) ) {
                continue;
            }

            visited.Add( current );

            if ( MoveUtilities.HorizontalDistanceBetweenIndexes(start, current) < range ) {
                foreach ( Vector3Int direction in directions ) {
                    Vector3Int neighbor = current + direction;
                    if ( !visited.Contains( neighbor ) && this.containsIndex( neighbor ) ) {
                        stack.Push( neighbor );
                    }

                }
            }
            
        }
        
        return visited;
    }



    /// <summary>
    /// Checks whether index exists on map.
    /// </summary>
    /// <param name="v">The index to check.</param>
    /// <returns>True if index is part of map.</returns>
    public static bool containsIndex(Vector3Int v) {
        if (!_instance) {
            return false;
        }

        if ( v.x < 0 || v.x >= this._dimensions.x ) {
            return false;
        }
        if ( v.y < 0 || v.y >= this._dimensions.y ) {
            return false;
        }
        if ( v.z < 0 || v.z >= this._dimensions.z ) {
            return false;
        }
        return true;
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
