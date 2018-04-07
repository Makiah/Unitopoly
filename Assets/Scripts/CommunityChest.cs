using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunityChest : BoardLocation 
{
    public override void PassBy(Player player)
    {
        Debug.Log("Passed by community chest");
    }

    public override IEnumerator LandOn(Player player)
    {
        Debug.Log("Landed on community chest");

        yield return null;
    }
}
