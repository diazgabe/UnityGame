using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Battle : MonoBehaviour, IConfigurable{

    private static Battle _instance;
    
    private Map map;
    private List<IUnit> Allies;
    private List<IUnit> Enemies;
    private string filePath = "Assets/Resources/jsons/testMap.json";
    private GameObject Ally;
    private GameObject Enemy;

    private Player[] players;
    private BaseTurnTracker TurnTracker;
    
    private void Awake() {
        if ( _instance != null && _instance != this ) {
            Destroy( this.gameObject );
        } else {
            _instance = this;
        }

        Ally = Resources.Load<GameObject>("Prefabs/Units/Ally");
        Enemy = Resources.Load<GameObject>("Prefabs/Units/Enemy");
    }

	// Use this for initialization
	private void Start () {
        string jsonData = File.ReadAllText(filePath);
        BattleConfig battleConfig = JsonUtility.FromJson<BattleConfig>(jsonData);

        MapConfig mapConfig = battleConfig.map;
        initializeMap(mapConfig);
        initializeTurnTracker();
        initializeUnits(battleConfig.Allies, battleConfig.Enemies);
    }
	
	// Update is called once per frame
	private void Update () {
		
	}

    public void configure(IConfig config) {
        BattleConfig battleConfig = config as BattleConfig;
    }

    private void initializeMap(MapConfig mapConfig) {
        map = this.gameObject.AddComponent<Map>();
        map.configure(mapConfig);
    }

    private void initializeTurnTracker() {
        TurnTracker = new BaseTurnTracker();
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

    private void startNextTurn() {
        Turn turn = TurnTracker.advanceTurn();
        turn.getPlayer().takeTurn();
    }
}
