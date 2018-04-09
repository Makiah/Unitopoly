using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : BoardLocation
{
    [SerializeField] private String propertyName = "";

    [Tooltip("These are cumulative, don't write total price")]
    [SerializeField] private int[] purchasePrices = new int[6];
    
    [Tooltip("These are NOT cumulative, write total price")]
    [SerializeField] private int[] rentPrices = new int[6];

    [SerializeField] private int mortgageValue;
    
    [SerializeField] private Property[] sameColorProperties;

    private int currentUpgradeLevel;

    [HideInInspector] public Player ownedBy = null;
    
    public override void PassBy(Player player)
    {
    }

    protected override IEnumerator PropertySpecificActions(Player player)
    {
        if (ownedBy == null)
        {
            yield return ChoiceAlert.instance.CreateChoiceAlert("Buy " + propertyName + "?",
                Color.green, "M" + purchasePrices[0],
                Color.yellow, "Nope");

            if (ChoiceAlert.instance.resultingDecision)
            {
                ownedBy = player;
                player.AdjustBalanceBy(-purchasePrices[0]);
            }
        }
        else
        {
            if (ownedBy == player)
            {
                yield return MessageAlert.instance.DisplayAlert("You own this property!", Color.green);
            }
            else
            {
                yield return MessageAlert.instance.DisplayAlert("Rent owed: M" + rentPrices[currentUpgradeLevel], Color.red);
                player.AdjustBalanceBy(-rentPrices[currentUpgradeLevel]);
                ownedBy.AdjustBalanceBy(rentPrices[currentUpgradeLevel]);
            }
        }
    }
}
