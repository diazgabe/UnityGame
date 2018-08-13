using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Manages the game's saves.
/// </summary>
public class SaveSystem : MonoBehaviour {

    private static SaveSystem _instance;

    private static string saveFolderPath = "Saves";
    private const int maxNumberOfSaves = 3;

    private void Awake() {
        if ( _instance == null ) {
            _instance = this;
        } else if ( _instance != this ) {
            Destroy( this.gameObject );
        }


    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SaveListener( ) {
        Debug.Log( "Save start." );
    }

    public static void Save( int index = 0 ) {
        Debug.Log( "Save start." );
        if ( index < 0 || index == maxNumberOfSaves ) {
            Debug.LogError( "Attempted to save game to slot " + index + " . Only slots 0 - " + (maxNumberOfSaves - 1) + " exist." );
        } else {
            string saveFile = Game.toJson();
            string savePath = saveFolderPath + "/" + index + ".json";
            if ( !File.Exists( saveFolderPath ) ) {
                Directory.CreateDirectory( saveFolderPath );
            }
            if ( !File.Exists( savePath ) ) {
                File.Create(savePath);
            }
            File.WriteAllText(savePath, saveFile);
        }
        Debug.Log("Save successful.");
    }

    public static void Load( int index ) {
        if ( index < 0 || index == maxNumberOfSaves ) {
            Debug.LogError( "Attempted to load game from slot " + index + " . Only slots 0 - " + ( maxNumberOfSaves - 1 ) + " exist." );
        } else {
            string savePath = saveFolderPath + "/" + index + ".json";
            if ( File.Exists(savePath) ) {
                string saveData = File.ReadAllText(savePath);
                Game.load(saveData);
            } else {
                Debug.LogError( "Attempted to load game from empty slot " + index + " ." );
            }
        }
    }

    public static FileInfo[] getSaveFileInfos() {
        DirectoryInfo DI = new DirectoryInfo(saveFolderPath);
        FileInfo[] files = DI.GetFiles();

        return files;
    }
}
