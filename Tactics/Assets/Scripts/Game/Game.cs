using UnityEngine;
using UnityEngine.SceneManagement;

public class Game: MonoBehaviour {

    private static Game _instance;
    public static Game Instance { get { return _instance; } }

    private void Awake() {
        if ( _instance != null ) {
            Destroy( gameObject );
        } else {
            _instance = this;
        }
    }

    private void startBattle() {
        SceneManager.LoadScene( "Battle" );
    }

}
