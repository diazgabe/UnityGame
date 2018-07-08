using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour {

    private MapGenerator MapGenerator;
    private Vector2Int mapDimensions = new Vector2Int(5,5);
    private BaseUnit[] allies;
    private BaseUnit[] enemies;
    private TurnTracker turnTracker;

    public GameObject unit;
    public GameObject currentUnit;

    void Awake() {

        MapGenerator = new LandMapGenerator(mapDimensions);

        Vector3 unitPosition = new Vector3(Random.Range(0, mapDimensions.x), 1f, Random.Range(0, mapDimensions.y));
        currentUnit = Instantiate(unit, unitPosition, Quaternion.identity);

        turnTracker = new TurnTracker();
    }

    // Use this for initialization
    void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }
}
