using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GlobalScript.itemIndex = new ItemScript[21]
        {
        //Ores (Sale value, weight, name)
        new OreScript(5, 1, StringResources.strCopper[GlobalScript.languageSelection]),
        new OreScript(10, 2, StringResources.strIron[GlobalScript.languageSelection]),
        new OreScript(30, 5, StringResources.strSilver[GlobalScript.languageSelection]),
        new OreScript(50, 5, StringResources.strGold[GlobalScript.languageSelection]),
        new OreScript(20, 1, StringResources.strMithril[GlobalScript.languageSelection]),
        new OreScript(100, 3, StringResources.strStarmetal[GlobalScript.languageSelection]),
        //Gems & Treasures (Sale value, weight, name)
        new OreScript(5, 2, StringResources.strCoal[GlobalScript.languageSelection]),
        new OreScript(10, 1, StringResources.strAgate[GlobalScript.languageSelection]),
        new OreScript(10, 1, StringResources.strQuartz[GlobalScript.languageSelection]),
        new OreScript(15, 2, StringResources.strTurquoise[GlobalScript.languageSelection]),
        new OreScript(15, 1, StringResources.strGarnet[GlobalScript.languageSelection]),
        new OreScript(15, 1, StringResources.strPeridot[GlobalScript.languageSelection]),
        new OreScript(20, 2, StringResources.strAmber[GlobalScript.languageSelection]),
        new OreScript(20, 1, StringResources.strAmethyst[GlobalScript.languageSelection]),
        new OreScript(20, 1, StringResources.strTopaz[GlobalScript.languageSelection]),
        new OreScript(30, 2, StringResources.strJade[GlobalScript.languageSelection]),
        new OreScript(30, 1, StringResources.strEmerald[GlobalScript.languageSelection]),
        new OreScript(30, 1, StringResources.strSapphire[GlobalScript.languageSelection]),
        new OreScript(150, 5, StringResources.strRelic[GlobalScript.languageSelection]),
        new OreScript(100, 1, StringResources.strRuby[GlobalScript.languageSelection]),
        new OreScript(100, 1, StringResources.strDiamond[GlobalScript.languageSelection]),
        };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
