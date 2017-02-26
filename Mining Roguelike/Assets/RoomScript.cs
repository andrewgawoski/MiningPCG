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
    public GameObject rockPrefab;

    GameObject[,] groundArray;
    GameObject[,] objectArray;

	// Use this for initialization
	void Start () {
        lowerBound = 5 + Mathf.FloorToInt(GlobalScript.floorLevel / 4);
        upperBound = 5 + Mathf.FloorToInt(GlobalScript.floorLevel / 2);

        //Generate room bounds
        Random.InitState(Mathf.FloorToInt(UnityEngine.Time.time));

        //X dimension Room (Actual size = 5, indices 0-4)
        xDim = Mathf.Min(Random.Range(lowerBound, upperBound + 1), maxDim);
        //Y dimension Room
        yDim = Mathf.Min(Random.Range(lowerBound, upperBound + 1), maxDim);

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
                    //groundArray[x, y].GetComponent<GroundScript>().ladderSpawn = true;
                    
                }

                //Generate Rock Object Here
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
