using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassGo : BoardLocation
{
    public static PassGo instance;

    protected override void AdditionalInit()
    {
        instance = this;
    }
    
    public override void PassBy(Player player)
    {
    }

    protected override IEnumerator PropertySpecificActions(Player player)
    {
        yield return null;
    }
}
