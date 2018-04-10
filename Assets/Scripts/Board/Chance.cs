using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chance : BoardLocation 
{
    public override void PassBy(Player player)
    {
        Debug.Log("Passed by Chance");
    }

    public override IEnumerator LandOn(Player player)
    {
        Debug.Log("Landed on Chance");

        yield return null;
    }
}
