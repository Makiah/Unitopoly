using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToJail : BoardLocation 
{
    public override void PassBy(Player player)
    {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator PropertySpecificActions(Player player)
    {
        throw new System.NotImplementedException();
    }
}
