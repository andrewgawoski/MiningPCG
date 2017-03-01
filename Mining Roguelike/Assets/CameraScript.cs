using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    Camera thisCamera;

    void adjustCamera(int xDimension, int yDimension)
    {
        Debug.Log("Adjusting Camera: " + xDimension + " " + yDimension);
        
        //Center the camera on the room
        Vector3 targetPosition = new Vector3(0.5f*GlobalScript.tileOffset * (xDimension - 1), 0.5f*GlobalScript.tileOffset * (yDimension - 1), thisCamera.transform.position.z);
        thisCamera.transform.position = targetPosition;


        //Resize the camera
        //thisCamera.orthographicSize = 220.0f;
    }

	// Use this for initialization
	void Start () {

        thisCamera = Camera.main;

        thisCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        //Camera.main.
        //Camera.main.orthographicSize = 220.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
        {
            Vector2 tempVec = GameObject.Find("Room Controller").GetComponent<RoomScript>().getRoomDimensions();
            adjustCamera(Mathf.FloorToInt(tempVec.x), Mathf.FloorToInt(tempVec.y));
        }
	}
}
