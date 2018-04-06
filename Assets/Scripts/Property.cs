using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : BoardLocation
{
    [SerializeField] private String propertyName = "";
    [SerializeField] private int propertyPurchasePrice;
    [SerializeField] private Property[] sameColorProperties;
    [SerializeField] private int[] constructionPrices = new int[5];
    
    public override void PassBy(Player player)
    {
        Debug.Log("Passed by property");
    }

    public override void LandOn(Player player)
    {
        Debug.Log("Landed on property");
    }
}
