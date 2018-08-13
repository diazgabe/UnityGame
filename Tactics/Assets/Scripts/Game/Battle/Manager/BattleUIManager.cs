using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class BattleUIManager : UIManager {

    private static UIManager _instance;

    protected override void Awake() {
        if ( _instance != null && _instance != this ) {
            Destroy( this.gameObject );
        } else {
            _instance = this;
        }
    }

    // Use this for initialization
    private void Start () {
		
	}

    // Update is called once per frame
    private void Update () {
		
	}

    public void attackButtonClick() {
        EventManager.TriggerEvent("Attack");
    }

    public void moveButtonClick() {
        EventManager.TriggerEvent("Move");
    }

    public void rotateCounterClockwise() {
        Debug.Log( "rotateCounterClockwise" );
        EventManager.TriggerEvent( "RotateCounterClockwise" );
    }

    public void rotateClockwise() {
        Debug.Log( "rotateCounterClockwise" );
        EventManager.TriggerEvent( "RotateClockwise" );
    }

    public void saveClick() {
        EventManager.TriggerEvent( "Save" );
    }

    private void Init() {

    }

    public override void loadUI() {
        throw new System.NotImplementedException();
    }
}
