using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour {

    private float moveSpeed = 5;
    public bool isBlocked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void moveTowards(Vector3 newPos) {
        StartCoroutine(animateMove(newPos));       
    }

    //changeName
    private IEnumerator animateMove(Vector3 newPos) {
        isBlocked = true;

        float step = this.moveSpeed * Time.deltaTime;
        while (this.transform.position != newPos) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, newPos, step);
            yield return null;
        }

        isBlocked = false;
    }

}
