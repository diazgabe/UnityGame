using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenGameManager : MonoBehaviour {

    string UIFolderPath;

    private void Awake() {
        
    }

    // Use this for initialization
    private void Start () {
        this.subscribeToEvents();
    }

    // Update is called once per frame
    private void Update () {
		
	}

    private void subscribeToEvents() {
        EventManager.addEventListener( "NewGame", NewGame );
        EventManager.addEventListener( "LoadGame", LoadGame );
    }

    private void NewGame() {
        Game.initializeNewGame();
        SceneManager.LoadScene( "Game" );
    }

    private void LoadGame() {
        SaveSystem.Load(0);
        SceneManager.LoadScene( "Game" );
    }

    private void LoadUI() {

    }
}
