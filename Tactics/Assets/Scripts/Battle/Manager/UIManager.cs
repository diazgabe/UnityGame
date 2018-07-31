using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour {

    private static UIManager _instance;

    private void Awake() {
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

    private void Init() {

    }

    //private void loadFromJson(string filePath) {
    //    string jsonData = File.ReadAllText(filePath);
    //    Dictionary<string, string> eventDictionary = JsonUtility.FromJson<Dictionary<string, string>>(jsonData);
    //    foreach (string key in eventDictionary.Keys) {
    //        EventManager.addEventListener(key, eventDictionary[key]);
              // I could do this with reflection but it seems weird. Must be a better way.
    //    }
    //}
}
