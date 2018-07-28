using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private IStateMachine _StateMachine;
    //public IUnit activeUnit;

    private void Awake() {
        
    }

    // Use this for initialization
    void Start() {
        _StateMachine = new TestStateMachine();
        //UIManager.AttackButtonClick.AddListener(new UnityEngine.Events.UnityAction(onAttackButtonClick));
        //UIManager.MoveButtonClick.AddListener(new UnityEngine.Events.UnityAction(onMoveButtonClick));
    }

    // Update is called once per frame
    void Update() {
        handleInput();
        //if (Input.GetMouseButtonDown(0)) {
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit)) {
        //        if (hit.collider.tag == "Tile" && activeUnit.isBlocked == false) {
        //            if (activeUnit != null) {
        //                Vector3 newPos = hit.transform.position;
        //                newPos.y = 1;
        //                activeUnit.moveTowards(newPos);
        //            }
        //        }
        //        else if (hit.collider.tag == "Unit") {
        //            activeUnit = hit.collider.gameObject.GetComponent("GameUnit") as GameUnit;
        //            Debug.Log("Unit selected.");
        //        }
        //    }
        //}
    }

    void handleInput() {
        
    }

    void handleInputIdle() {
        //if (Input.GetMouseButtonDown(0)) {
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit)) {
        //        if (hit.collider.tag == "Tile" && activeUnit.isBlocked == false) {
        //            if (activeUnit != null) {
        //                Vector3 newPos = hit.transform.position;
        //                newPos.y = 1;
        //                activeUnit.moveTowards(newPos);
        //            }
        //        }
        //        else if (hit.collider.tag == "Unit") {
        //            activeUnit = hit.collider.gameObject.GetComponent("GameUnit") as GameUnit;
        //            Debug.Log("Unit selected.");
        //        }
        //    }
        //}
    }

    void handleInputMove() {
        //if (Input.GetMouseButtonDown(0)) {
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit)) {
        //        if (hit.collider.tag == "Tile" && activeUnit.isBlocked == false) {
        //            if (activeUnit != null) {
        //                Vector3 newPos = hit.transform.position;
        //                newPos.y = 1;
        //                activeUnit.moveTowards(newPos);
        //            }
        //        }
        //        else if (hit.collider.tag == "Unit") {
        //            activeUnit = hit.collider.gameObject.GetComponent("GameUnit") as GameUnit;
        //            Debug.Log("Unit selected.");
        //        }
        //    }
        //}
    }

    void handleInputAttack() {
        //if (Input.GetMouseButtonDown(0)) {
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit)) {
        //        if (hit.collider.tag == "Tile" && activeUnit.isBlocked == false) {
        //            if (activeUnit != null) {
        //                Vector3 newPos = hit.transform.position;
        //                newPos.y = 1;
        //                activeUnit.moveTowards(newPos);
        //            }
        //        }
        //        else if (hit.collider.tag == "Unit") {
        //            activeUnit = hit.collider.gameObject.GetComponent("GameUnit") as GameUnit;
        //            Debug.Log("Unit selected.");
        //        }
        //    }
        //}
    }


    void onAttackButtonClick() {
        Debug.Log("Player clicked attack button.");
    }

    void onMoveButtonClick() {
        Debug.Log("Player clicked move button.");
    }
}
