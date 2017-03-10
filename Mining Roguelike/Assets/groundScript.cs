using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundScript : MonoBehaviour {

    public bool ladderSpawn = false;
    public bool tileUsed;

    public void digTile()
    {
        makeTileUsed();
    }

    void makeTileUsed()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        tileUsed = true;
    }
    
	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().enabled = false;
        tileUsed = false;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
