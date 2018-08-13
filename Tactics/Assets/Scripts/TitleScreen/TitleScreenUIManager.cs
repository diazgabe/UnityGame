using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenUIManager : UIManager {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadClick() {
        EventManager.TriggerEvent("LoadGame");
    }

    public void newGameClick() {
        Debug.Log("TitleScreen: Clicked New Game.");
        EventManager.TriggerEvent( "NewGame" );
    }

    public override void loadUI() {
        throw new System.NotImplementedException();
    }
}
