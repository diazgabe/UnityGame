using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    private Dictionary<string, UnityEvent> eventDictionary;

    UnityEvent turnFinishedEvent;

    private void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
        }
        else {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void triggerEvent(string eventName) {

    }

    //private void loadDictionaryFromFile() {

    //}
}
