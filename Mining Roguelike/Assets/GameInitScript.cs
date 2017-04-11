using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitScript : MonoBehaviour {

    //Populates the dictionary of all word strings with appropriately localized words
    void initializeDictionary()
    {
        GlobalScript.fullWords = new Dictionary<string, string>();

        GlobalScript.fullWords.Add("New Game", "New Game");
        GlobalScript.fullWords.Add("Continue", "Continue");
        GlobalScript.fullWords.Add("Quit", "Quit");
        GlobalScript.fullWords.Add("Stamina", "Stamina");
        GlobalScript.fullWords.Add("star", "star");
        GlobalScript.fullWords.Add("copper", "copper");
        GlobalScript.fullWords.Add("iron", "iron");
        GlobalScript.fullWords.Add("gold", "gold");
        GlobalScript.fullWords.Add("silver", "silver");
        GlobalScript.fullWords.Add("electrum", "electrum");
        GlobalScript.fullWords.Add("steel", "steel");
        GlobalScript.fullWords.Add("mithril", "mithril");
        GlobalScript.fullWords.Add("starmetal", "starmetal");
        GlobalScript.fullWords.Add("fabled", "fabled");
        GlobalScript.fullWords.Add("coal", "coal");
        GlobalScript.fullWords.Add("agate", "agate");
        GlobalScript.fullWords.Add("quartz", "quartz");
        GlobalScript.fullWords.Add("turquoise", "turquoise");
        GlobalScript.fullWords.Add("garnet", "garnet");
        GlobalScript.fullWords.Add("peridot", "peridot");
        GlobalScript.fullWords.Add("amber", "amber");
        GlobalScript.fullWords.Add("amethyst", "amethyst");
        GlobalScript.fullWords.Add("topaz", "topaz");
        GlobalScript.fullWords.Add("jade", "jade");
        GlobalScript.fullWords.Add("emerald", "emerald");
        GlobalScript.fullWords.Add("sapphire", "sapphire");
        GlobalScript.fullWords.Add("ancient relic", "ancient relic");
        GlobalScript.fullWords.Add("ruby", "ruby");
        GlobalScript.fullWords.Add("diamond", "diamond");
        GlobalScript.fullWords.Add("bread", "bread");
    }

    //Populates the array of item (information) in GlobalScript with values and appropriate names
    void initilizeItemArray()
    {
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

	// Use this for initialization
	void Start () {
        initializeDictionary();
        initilizeItemArray();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
