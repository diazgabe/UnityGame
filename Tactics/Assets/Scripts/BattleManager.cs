using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour {

    private IMapGenerator MapGenerator;
    private IMap Map;
    private Vector3Int mapDimensions = new Vector3Int(5, 5, 5);
    private BaseUnit[] allies;
    private BaseUnit[] enemies;
    private TurnTracker turnTracker;

    public GameObject unit;
    public GameObject currentUnit;

    void Awake() {
        
    }

    void Start () {
        setUpMap();
        setUpUnits();

        turnTracker = new TurnTracker();
    }

    private void setUpMap() {
        MapGenerator = new LandMapGenerator(mapDimensions);
        Map = MapGenerator.generateMap();
    }

    private void setUpUnits() {
        Vector3 unitPosition = new Vector3(Random.Range(0, mapDimensions.x), 1f, Random.Range(0, mapDimensions.y));
        currentUnit = Instantiate(unit, unitPosition, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }
}
