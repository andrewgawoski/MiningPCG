using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class OreScript : ItemScript {

    public int salePrice { get; set;}

}

public class CopperOre : OreScript
{

    new int salePrice = 5;
    new int itemWeight = 1;
    //new string itemName = "Copper";
    new string itemName = StringResources.strCopper[GlobalScript.languageSelection];

}

public class IronOre : OreScript
{

    new int salePrice = 10;
    new int itemWeight = 2;
    new string itemName = StringResources.strIron[GlobalScript.languageSelection];

}

public class SilverOre : OreScript
{

    new int salePrice = 30;
    new int itemWeight = 5;
    new string itemName = StringResources.strSilver[GlobalScript.languageSelection];

}

public class GoldOre : OreScript
{

    new int salePrice = 50;
    new int itemWeight = 5;
    new string itemName = StringResources.strGold[GlobalScript.languageSelection];

}

public class MithrilOre : OreScript
{

    new int salePrice = 20;
    new int itemWeight = 1;
    new string itemName = StringResources.strMithril[GlobalScript.languageSelection];

}

public class StarmetalOre : OreScript
{

    new int salePrice = 100;
    new int itemWeight = 3;
    new string itemName = StringResources.strStarmetal[GlobalScript.languageSelection];

}
