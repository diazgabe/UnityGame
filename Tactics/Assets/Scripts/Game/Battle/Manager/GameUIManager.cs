using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : UIManager {

    protected override void Awake() {
        base.Awake();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartAIBattle() {
        EventManager.TriggerEvent( "StartAIBattle" );
    }

    public void SaveGame() {
        Debug.Log("SaveGame click");
        EventManager.TriggerEvent( "SaveGame" );
    }

    public void showUnitCreationUI() {

    }

    public override void loadUI() {
        
    }
}