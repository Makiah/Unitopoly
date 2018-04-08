using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : BoardLocation
{
    [SerializeField] public String propertyName = "";
    [SerializeField] public int propertyPurchasePrice;
    [SerializeField] private Property[] sameColorProperties;
    [SerializeField] private int[] constructionPrices = new int[5];

    [HideInInspector] public Player ownedBy = null;
    
    public override void PassBy(Player player)
    {
    }

    protected override IEnumerator PropertySpecificActions(Player player)
    {
        yield return PropertyPurchaser.instance.SuggestNewPurchase(player, this);
    }
}
