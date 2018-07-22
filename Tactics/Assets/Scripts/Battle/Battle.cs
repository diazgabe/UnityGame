using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Battle : MonoBehaviour, IConfigurable{

    private Map map;
    private string filePath = "Assets/Resources/jsons/testMap.json";


    void Awake() {

    }

	// Use this for initialization
	void Start () {
        //serializeBattleTest();
        string jsonData = File.ReadAllText(filePath);
        BattleConfig battleConfig = JsonUtility.FromJson<BattleConfig>(jsonData);
        Debug.Log(JsonUtility.ToJson(battleConfig.map));
        MapConfig mapConfig = battleConfig.map;
        this.gameObject.AddComponent<Map>();
        map = this.gameObject.GetComponent<Map>();
        map.configure(mapConfig);
        //configure(battleConfig);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void configure(IConfig config) {
        BattleConfig battleConfig = config as BattleConfig;
        
    }

    public void mapTest() {
        filePath = "Assets/Resources/jsons/mapTest.json";
        string jsonData = File.ReadAllText(filePath);
        Debug.Log("Data = " + jsonData);
        MapConfig config = JsonUtility.FromJson<MapConfig>(jsonData);
        Debug.Log(config.dimensions);
        foreach (TileConfig i in config.tiles) {
            Debug.Log("Tile " + i.index + ": " + i.tileType);
        }
    }

    public void tileTest() {
        filePath = "Assets/Resources/jsons/tileTest.json";
        string jsonData = File.ReadAllText(filePath);
        TileConfig tileConfig = JsonUtility.FromJson<TileConfig>(jsonData);
        Debug.Log(tileConfig.tileType);
        Debug.Log(tileConfig.index);
    }

    public void serializeTileTest() {
        TileConfig g = new TileConfig();
        g.tileType = TileType.Water;
        g.index = Vector3Int.one;
        Debug.Log(JsonUtility.ToJson(g));
    }

    public void serializeMapTest() {
        TileConfig[] tiles = new TileConfig[2];
        TileConfig t1 = new TileConfig();
        t1.tileType = TileType.Lava;
        t1.index = new Vector3Int(1, 2, 3);
        TileConfig t2 = new TileConfig();
        t2.tileType = TileType.Water;
        t2.index = new Vector3Int(3, 2, 1);
        tiles[0] = t1;
        tiles[1] = t2;

        MapConfig g = new MapConfig();
        g.dimensions = Vector3Int.one;
        g.tiles = tiles;

        Debug.Log(JsonUtility.ToJson(g));
    }

    public void serializeBattleTest() {
        TileConfig tile = new TileConfig();
        tile.tileType = TileType.Lava;
        tile.index = Vector3Int.zero;

        MapConfig map = new MapConfig();
        map.dimensions = Vector3Int.one;
        TileConfig[] tiles = new TileConfig[1];
        tiles[0] = tile;
        map.tiles = tiles;

        BattleConfig battleConfig = new BattleConfig();
        battleConfig.map = map;

        Debug.Log(JsonUtility.ToJson(battleConfig));
    }
}
