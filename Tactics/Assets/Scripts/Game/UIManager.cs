using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIManager : MonoBehaviour, IUIManager {

    List<GameObject> Panels;

    protected virtual void Awake() {
        loadUI();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void activatePanel(GameObject panel) {
        
    }

    public abstract void loadUI();

}
