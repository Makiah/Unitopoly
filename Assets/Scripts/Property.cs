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

    [HideInInspector] public Player ownedBy = null;
    
    public override void PassBy(Player player)
    {
        Debug.Log("Passed by property");
    }

    public override IEnumerator LandOn(Player player)
    {
        Debug.Log("Landed on property");
        player.AdjustBalanceBy(-propertyPurchasePrice);
        yield return null;
    }
}
