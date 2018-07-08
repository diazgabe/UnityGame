using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameUnit activeUnit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag == "Tile" && activeUnit.isBlocked == false) {
                    if (activeUnit != null) {
                        Vector3 newPos = hit.transform.position;
                        Debug.Log("Tile selected.");
                        newPos.y = 1;
                        activeUnit.moveTowards(newPos);
                        Debug.Log("Unit moved.");
                    }
                }
                else if (hit.collider.tag == "Unit") {
                    activeUnit = hit.collider.gameObject.GetComponent("GameUnit") as GameUnit;
                    Debug.Log("Unit selected.");
                }
            }
        }
    }

}
