using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeTax : BoardLocation 
{
    public override void PassBy(Player player)
    {
    }

    protected override IEnumerator PropertySpecificActions(Player player)
    {
        yield return null;
    }
}
