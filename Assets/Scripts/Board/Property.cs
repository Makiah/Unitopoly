using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : Ownable
{   
    [Tooltip("These are cumulative, don't write total price")]
    [SerializeField] private int housePrice;
    
    [Tooltip("These are NOT cumulative, write total price")]
    [SerializeField] private int[] rentPrices = new int[6];
    
    private int currentUpgradeLevel;

    protected override int ChargePlayer()
    {
        return rentPrices[currentUpgradeLevel];
    }
}
