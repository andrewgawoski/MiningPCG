using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour {

    public static int languageSelection = 0;
    public static int floorLevel = 15;
    public static readonly int tileOffset = 66;
    public static bool insideMine = true;
    public static bool playerHasControl = false;
    public static ItemScript[] itemIndex = new ItemScript[2] {
        //Ores (sale, weight, name)
        new OreScript(5,1,StringResources.strCopper[GlobalScript.languageSelection]),
        new OreScript(3,5,"uh huh")
        //Gems & Treasures
    };
}
