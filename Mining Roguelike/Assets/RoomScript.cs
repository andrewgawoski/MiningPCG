using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {


    //We want at minimum a 5x5 (IE, a 0-4x0-4) because its really a 3x3 as the edges don't have ladders.

    int lowerBound;
    int upperBound;
    int xDim;
    int yDim;
    int maxDim = 30;
    int playerSpawnX;
    int playerSpawnY;
    int ladderSpawnX;
    int ladderSpawnY;
    float rockDensity;

    public GameObject tilePrefab;
    public GameObject wallPrefab;
    public GameObject cornerPrefab;
    public GameObject rockPrefab;
    GameObject playerReference;

    GameObject[,] groundArray;
    GameObject[,] objectArray;

    public Vector2 getRoomDimensions()
    {
        return new Vector2(xDim, yDim);
    }

	// Use this for initialization
	void Start () {

        playerReference = GameObject.FindGameObjectWithTag("Player");

        lowerBound = 5 + Mathf.FloorToInt(GlobalScript.floorLevel / 4);
        upperBound = 5 + Mathf.FloorToInt(GlobalScript.floorLevel / 2);

        //Generate room bounds
        //Random.InitState(Mathf.FloorToInt(UnityEngine.Time.time));

        //X dimension Room (Actual size = 5, indices 0-4)
        xDim = Mathf.Min(Random.Range(lowerBound, upperBound + 1), maxDim);
        Debug.Log("xDim is " + xDim);
        //Y dimension Room
        yDim = Mathf.Min(Random.Range(lowerBound, upperBound + 1), maxDim);
        Debug.Log("yDim is " + yDim);

        //Initlizing spawn positions
        playerSpawnX = Random.Range(0, xDim);
        playerSpawnY = Random.Range(0, yDim);
        ladderSpawnX = Random.Range(1, xDim - 1);
        ladderSpawnY = Random.Range(1, yDim - 1);

        //Initilizing room info arrays
        groundArray = new GameObject[xDim, yDim];
        objectArray = new GameObject[xDim, yDim];

        //Determining rock density
        rockDensity = Random.Range(0.25f,Mathf.Min(0.75f, 0.33f + 0.01f * GlobalScript.floorLevel));

        //Time to iterate through the arrays
        for(int x = 0; x < xDim; x++)
        {
            for(int y = 0; y < yDim; y++)
            {
                //x and y for coordinates respectively

                //Generate Ground Tile Here
                groundArray[x, y] = GameObject.Instantiate(tilePrefab);
                groundArray[x, y].transform.position = new Vector3(x * GlobalScript.tileOffset, y * GlobalScript.tileOffset, 0.0f);

                if (ladderSpawnX == x && ladderSpawnY == y)
                {
                    //Make it a special ground tile that spawns the ladder down
                    groundArray[x, y].GetComponent<groundScript>().ladderSpawn = true;
                    
                }

                //Generate Rock Object Here (Make sure it isn't on the determined player spawn point)

                //if(x != playerSpawnX && y != playerSpawnY)
                if (new Vector2(x, y) != new Vector2(playerSpawnX, playerSpawnY))
                {
                    //We can try to spawn a rock
                    if(Random.value <= rockDensity)
                    {
                        GameObject tempRock = GameObject.Instantiate(rockPrefab);
                        tempRock.transform.position = new Vector3(x * GlobalScript.tileOffset, y * GlobalScript.tileOffset, 0.0f);
                    }
                }

                //Generate left wall
                GameObject tempLeft = GameObject.Instantiate(wallPrefab);
                tempLeft.transform.position = new Vector3((-1) * GlobalScript.tileOffset, y * GlobalScript.tileOffset, 0.0f);
                tempLeft.transform.GetChild(0).transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));
                //Generate right wall
                GameObject tempRight = GameObject.Instantiate(wallPrefab);
                tempRight.transform.position = new Vector3(xDim * GlobalScript.tileOffset, y * GlobalScript.tileOffset, 0.0f);
                tempRight.transform.GetChild(0).transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
            }

            //Generate bottom wall
            GameObject tempBot = GameObject.Instantiate(wallPrefab);
            tempBot.transform.position = new Vector3(x * GlobalScript.tileOffset, (-1) * GlobalScript.tileOffset, 0.0f);

            //Generate top wall
            GameObject tempTop = GameObject.Instantiate(wallPrefab);
            tempTop.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipY = true;
            tempTop.transform.position = new Vector3(x * GlobalScript.tileOffset, yDim * GlobalScript.tileOffset, 0.0f);
        }

        //Move the player appropriately (player spawn point)
        playerReference.transform.position = new Vector3(playerSpawnX * GlobalScript.tileOffset, playerSpawnY * GlobalScript.tileOffset, 0.0f);

        //Generate the corners (bottom right and clockwise)
        GameObject tempCorner = GameObject.Instantiate(cornerPrefab);
        tempCorner.transform.position = new Vector3((xDim) * GlobalScript.tileOffset, (-1) * GlobalScript.tileOffset, 0.0f);

        tempCorner = GameObject.Instantiate(cornerPrefab);
        tempCorner.transform.position = new Vector3((-1) * GlobalScript.tileOffset, (-1) * GlobalScript.tileOffset, 0.0f);
        tempCorner.transform.GetChild(0).transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));

        tempCorner = GameObject.Instantiate(cornerPrefab);
        tempCorner.transform.position = new Vector3((-1) * GlobalScript.tileOffset, yDim * GlobalScript.tileOffset, 0.0f);
        tempCorner.transform.GetChild(0).transform.Rotate(new Vector3(0.0f, 0.0f, 180.0f));

        tempCorner = GameObject.Instantiate(cornerPrefab);
        tempCorner.transform.position = new Vector3(xDim * GlobalScript.tileOffset, yDim * GlobalScript.tileOffset, 0.0f);
        tempCorner.transform.GetChild(0).transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));

        //Eh, our room is generated at this point, lets resize the camera.
        Camera.main.GetComponent<CameraScript>().adjustCamera(xDim, yDim);

        //Make sure the player has control (can do things)
        GlobalScript.playerHasControl = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
