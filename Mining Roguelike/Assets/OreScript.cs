using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreScript : ItemScript {

    public int salePrice { get; set;}
    public OreScript(int sale, int weight, string name)
    {
        salePrice = sale;
        itemWeight = weight;
        itemName = name;
    }
    public OreScript()
    {
        salePrice = 0;
        itemWeight = 0;
        itemName = "???";
    }

}
