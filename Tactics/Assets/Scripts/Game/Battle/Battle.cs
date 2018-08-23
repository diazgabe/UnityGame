using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Battle : MonoBehaviour, IConfigurable{

    private static Battle _instance;
    
    private Map map;
    private List<IUnit> Allies;
    private List<IUnit> Enemies;
    private string filePath = "Assets/Resources/jsons/testMap.json";
    private string savePath = "Assets/Resources/jsons/testMap.json";
    private GameObject Ally;
    private GameObject Enemy;
    private List<Player> players;
    private TurnTracker TurnTracker;
    
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
        //initializeTurnTracker();
        //initializeUnits(battleConfig.Allies, battleConfig.Enemies);

        EventManager.addEventListener( "Save", save );
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
        TurnTracker = new TurnTracker( (List<BaseUnit>)Allies.Concat( Enemies ) );
    }

    private void initializeUnits(List<UnitConfig> allyConfigs, List<UnitConfig> enemyConfigs) {
        Allies = new List<IUnit>();
        foreach (UnitConfig unitConfig in allyConfigs) {
            GameObject newAlly = Instantiate(Ally);
            map.placeUnitOnIndex(newAlly, unitConfig.Index);
            newAlly.GetComponent<BaseUnit>().Index = unitConfig.Index;
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
        foreach ( Player player in turn.players ) {
            player.takeTurn();
        }
    }

    private void save() {
        Debug.Log( "Save" );
        string dataAsJson = JsonUtility.ToJson (this);
        File.WriteAllText( savePath, dataAsJson );
    }
}
