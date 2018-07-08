using UnityEngine;
using UnityEngine.Events;

public class BattleLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void turnFinished() {
        EventManager.triggerEvent("turnFinished");
    }
}
