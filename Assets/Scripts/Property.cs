using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : BoardLocation
{
    public override void PassBy(Player player)
    {
        Debug.Log("Passed by property");
    }

    public override void LandOn(Player player)
    {
        Debug.Log("Landed on property");
    }
}
