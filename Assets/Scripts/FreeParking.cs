using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeParking : BoardLocation 
{
    public override void PassBy(Player player)
    {
    }

    protected override IEnumerator PropertySpecificActions(Player player)
    {       
        yield return null;
    }
}
