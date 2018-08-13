using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Game: MonoBehaviour {

    private static Game _instance;
    public static Game Instance { get { return _instance; } }

    private List<UnitData> Units;

    private void Awake() {

        if ( _instance == null ) {
            _instance = this;
        } else if ( _instance != this ) {
            Destroy( this.gameObject );
        }

        DontDestroyOnLoad( this );

    }

    private void Start() {
        this.subscribeToEvents();
    }

    private void startBattleVsAI() {
        SceneManager.LoadScene( "Battle" );
    }

    public static string toJson() {
        return JsonUtility.ToJson( _instance );
    }

    public static void load(string saveData) {
        JsonUtility.FromJsonOverwrite( saveData, _instance );
    }

    public static void initializeNewGame() {
        _instance.Units = new List<UnitData>();
    }

    public void subscribeToEvents() {
        EventManager.addEventListener( "StartAIBattle", startBattleVsAI );
    }
}
