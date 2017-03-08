using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : ItemScript {

	public int purchasePrice { get; set; }
    public int restoreValue { get; set; }
    public FoodScript(int purchase, int restore, int weight, string name)
    {
        purchasePrice = purchase;
        restoreValue = restore;
        itemWeight = weight;
        itemName = name;
    }
}
