using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToJail : BoardLocation 
{
    public override void PassBy(Player player)
    {
    }

    public override IEnumerator LandOn(Player player)
    {
        yield return MessageAlert.instance.DisplayAlert("Uh oh...", Color.red);

        yield return player.JumpToSpace(InJail.instance, 2f);
        yield return player.RotateAdditionalDegrees(180, 1f);
    }
}
