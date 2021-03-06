﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    bool isMoving;
    Vector3 currentDestination;
    Vector3 currentDirection = Vector3.down;
    Vector3 originalPosition;

    //Up right down left in order (clockwise from top)
    float[] inputTimerArray;
    public float timerThreshold;
    public float timeToMove;
    float movementFraction = 0.0f;

    void changeDirection(Vector3 dirVector)
    {
        //Function to change player direction/facing without moving necessarily.
        if(dirVector != currentDirection)
        {
            Debug.Log("Changing Direction");
            currentDirection = dirVector;
        }
        
    }

    void swingHoe()
    {
        GameObject roomRef = GameObject.Find("Room Controller");

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(currentDirection.x, currentDirection.y), GlobalScript.tileOffset);
        if(hit.collider == null)
        {
            //We would be able to move (no rock or wall on the tile we're facing
            int tileX = Mathf.FloorToInt(GlobalScript.currentPlayerIndex.x + currentDirection.x);
            int tileY = Mathf.FloorToInt(GlobalScript.currentPlayerIndex.y + currentDirection.y);

            roomRef.GetComponent<RoomScript>().getTileReference(tileX, tileY).SendMessage("digTile");
        }
        else
        {
            //We can't dig the ground tile in front of us for some reason (might not be there)
        }
        
    }

    void movePlayer(Vector3 directionVector)
    {
        //Direction vector should always be "Vector3.up" etc.

        //Can we move to that location at all?
        //Ray2D locationChecker = new Ray
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(directionVector.x, directionVector.y), GlobalScript.tileOffset);

        if(hit.collider == null)
        {
            Debug.Log("We can move");
            //We need to make it so we can't move.
            isMoving = true;

            originalPosition = this.transform.position;
            currentDestination = this.transform.position + (GlobalScript.tileOffset * directionVector);

        }
        else
        {
            Debug.Log("We can't move");
            //Some redundancy
            isMoving = false;

        }
        
    }

	// Use this for initialization
	void Start () {
        isMoving = false;
        currentDestination = this.transform.position;
        inputTimerArray = new float[4] { 0.0f, 0.0f, 0.0f, 0.0f };
        timeToMove = 0.5f;
        timerThreshold = 10.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //We really can't do much if we're currently moving, other than move. So don't do anything otherwise.
		if(isMoving == false)
        {

            if(GlobalScript.playerHasControl)
            {

                if(Input.GetButtonDown("Jump"))
                {
                    swingHoe();
                }

                //Up Input
                if (Input.GetButton("Up"))
                {
                    inputTimerArray[0] += 1.0f;
                    Debug.Log("Trying up");
                    changeDirection(Vector3.up);

                    if (inputTimerArray[0] > timerThreshold)
                    {
                        movePlayer(Vector3.up);
                    }   
                }
                else
                {
                    inputTimerArray[0] = 0.0f;
                }

                if (Input.GetButtonUp("Up"))
                {
                    inputTimerArray[0] = 0.0f;
                }

                //Right Input
                if (Input.GetButton("Right"))
                {
                    inputTimerArray[1] += 1.0f;
                    Debug.Log("Trying right");
                    changeDirection(Vector3.right);

                    if (inputTimerArray[1] > timerThreshold)
                    {
                        movePlayer(Vector3.right);
                    }
                }
                else
                {
                    inputTimerArray[1] = 0.0f;
                }

                if (Input.GetButtonUp("Right"))
                {
                    inputTimerArray[1] = 0.0f;
                }

                //Down Input
                if (Input.GetButton("Down"))
                {
                    inputTimerArray[2] += 1.0f;
                    Debug.Log("Trying down");
                    changeDirection(Vector3.down);

                    if (inputTimerArray[2] > timerThreshold)
                    {
                        movePlayer(Vector3.down);
                    }
                }
                else
                {
                    inputTimerArray[2] = 0.0f;
                }

                if (Input.GetButtonUp("Down"))
                {
                    inputTimerArray[2] = 0.0f;
                }

                //Left Input
                if (Input.GetButton("Left"))
                {
                    inputTimerArray[3] += 1.0f;
                    Debug.Log("Trying left");
                    changeDirection(Vector3.left);

                    if (inputTimerArray[3] > timerThreshold)
                    {
                        movePlayer(Vector3.left);
                    }
                }
                else
                {
                    inputTimerArray[3] = 0.0f;
                }

                if (Input.GetButtonUp("Left"))
                {
                    inputTimerArray[3] = 0.0f;
                }


                //Confirm Input

                //Cancel Input

                //Start Input
            }

        }
        else
        {
            //We're moving, so we should check to see when we've reached our target destination.
            if(this.transform.position != currentDestination)
            {
                //We need to move!
                //tFrac += Time.smoothDeltaTime / timeToMove;
                movementFraction += Time.smoothDeltaTime / timeToMove;
                //this.transform.position = Vector3.Lerp(startPos, targetLocation, tFrac);
                this.transform.position = Vector3.Lerp(originalPosition, currentDestination, movementFraction);

            }
            else
            {
                //We're arrived
                movementFraction = 0.0f;
                originalPosition = this.transform.position;
                isMoving = false;
                GlobalScript.currentPlayerIndex = new Vector2(this.transform.position.x / GlobalScript.tileOffset, this.transform.position.y / GlobalScript.tileOffset);
                //inputTimerArray = new float[4] { 0, 0, 0, 0 };
            }
        }
	}
}
