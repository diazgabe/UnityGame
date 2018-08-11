using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the game's saves.
/// </summary>
public
    class SaveSystem : MonoBehaviour {

    private static SaveSystem _instance;

    private const int maxNumberOfSaves = 3;

    private void Awake() {
        if ( _instance != null ) {
            Destroy( gameObject );
        } else {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Save( int index ) {
        if ( index < 0 || index == maxNumberOfSaves ) {
            Debug.LogError( "Attempted to save game to slot " + index + " . Only slots 0 - " + (maxNumberOfSaves - 1) + " exist." );
        } else {

        }
    }
}
