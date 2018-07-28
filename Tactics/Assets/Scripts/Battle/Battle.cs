using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Battle : MonoBehaviour, IConfigurable{

    private Map map;
    private List<IUnit> Allies;
    private List<IUnit> Enemies;
    private string filePath = "Assets/Resources/jsons/testMap.json";
    private GameObject Ally;
    private GameObject Enemy;


    void Awake() {
        Ally = Resources.Load<GameObject>("Prefabs/Units/Ally");
        Enemy = Resources.Load<GameObject>("Prefabs/Units/Enemy");
    }

	// Use this for initialization
	void Start () {
        string jsonData = File.ReadAllText(filePath);
        BattleConfig battleConfig = JsonUtility.FromJson<BattleConfig>(jsonData);

        MapConfig mapConfig = battleConfig.map;
        initializeMap(mapConfig);

        initializeUnits(battleConfig.Allies, battleConfig.Enemies);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void configure(IConfig config) {
        BattleConfig battleConfig = config as BattleConfig;
        
    }

    private void initializeMap(MapConfig mapConfig) {
        map = this.gameObject.AddComponent<Map>();
        map.configure(mapConfig);
    }

    private void initializeUnits(List<UnitConfig> allyConfigs, List<UnitConfig> enemyConfigs) {
        Allies = new List<IUnit>();
        foreach (UnitConfig unitConfig in allyConfigs) {
            GameObject newAlly = Instantiate(Ally);
            map.placeUnitOnIndex(newAlly, unitConfig.Index);
            Allies.Add(newAlly.GetComponent<BaseUnit>());
        }

        Enemies = new List<IUnit>();
        foreach (UnitConfig unitConfig in enemyConfigs) {
            GameObject newEnemy = Instantiate(Enemy);
            map.placeUnitOnIndex(newEnemy, unitConfig.Index);
            Enemies.Add(newEnemy.GetComponent<BaseUnit>());
        }
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

        UnitConfig unit = new UnitConfig();
        unit.CurrentHP = 3;
        unit.MaxHP = 3;
        unit.Name = "test";
        unit.MoveRange = 3;
        unit.Index = Vector3Int.one;

        List<UnitConfig> Allies = new List<UnitConfig>();
        Allies.Add(unit);

        BattleConfig battleConfig = new BattleConfig();
        battleConfig.map = map;
        battleConfig.Allies = Allies;


        Debug.Log(JsonUtility.ToJson(battleConfig));
    }
}
