using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Camera cam;

    private const int panZone = 70;
    private int cameraSpeed { get; set; } = 7;

    private const int minZoom = 1;
    private const int maxZoom = 4;

    private int screenWidth;
    private int screenHeight;
    private Rect screen;

	// Use this for initialization
	void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        screen = new Rect(0, 0, screenWidth, screenHeight);
        cam = Camera.main;
    }
	
	void Update () {

        //Don't do anything if mouse is offscreen
        if (!screen.Contains(Input.mousePosition)) {
            return;
        }

        float distance = cameraSpeed * Time.deltaTime;

        //Horizontal
        if (Input.mousePosition.x < 0 + panZone) {
            transform.position += new Vector3(-distance, 0, distance);
        }
        if (Input.mousePosition.x > screenWidth - panZone) {
            transform.position += new Vector3(distance, 0, -distance);
        }

        //Vertical
        if (Input.mousePosition.y > screenHeight - panZone) {
            transform.position += new Vector3(0, distance, 0);
        }
        if (Input.mousePosition.y < 0 + panZone) {
            transform.position += new Vector3(0, -distance, 0);
        }

        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            if (cam.orthographicSize > minZoom) {
                cam.orthographicSize -= 1;
            }
        }
        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            if (cam.orthographicSize < maxZoom) {
                cam.orthographicSize += 1;
            }
        }
    }

}
