using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour {

    private void Awake() {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void attackButtonClick() {
        EventManager.TriggerEvent("Attack");
    }

    public void moveButtonClick() {
        EventManager.TriggerEvent("Move");
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
