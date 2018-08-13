using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventManager : MonoBehaviour {

    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    public Dictionary<string, UnityEvent> eventDictionary;

    UnityEvent turnFinishedEvent;

    private void Awake() {
        if ( _instance == null ) {
            _instance = this;
        } else if ( _instance != this ) {
            Destroy( this.gameObject );
        }
        initialize();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void addEventListener(string eventName, UnityAction listener) {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        } else {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener) {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName) {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke();
        }
    }

    private void initialize() {
        eventDictionary = new Dictionary<string, UnityEvent>();
    }
}
