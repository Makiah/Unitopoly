using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Railroad : BoardLocation
{
    [SerializeField] private string railroadName;
    [SerializeField] private int purchasePrice;
    [SerializeField] private Railroad[] otherRailroads;
    private Player ownedBy;

    public override void PassBy(Player player)
    {
    }

    protected override IEnumerator PropertySpecificActions(Player player)
    {
        if (ownedBy != null)
        {
            if (ownedBy != player)
            {
                // Determine how much to charge.  
                int toCharge = 25;
                foreach (Railroad railroad in otherRailroads)
                    if (railroad.ownedBy == ownedBy)
                        toCharge *= 2;

                yield return MessageAlert.instance.DisplayAlert("You'll have to pay M" + toCharge + "!", Color.red);
                
                player.AdjustBalanceBy(-toCharge);
            }
        }
        else
        {
            yield return ChoiceAlert.instance.CreateChoiceAlert("Would you like to buy " + railroadName + "?",
                Color.green, "M" + purchasePrice,
                Color.yellow, "Nope.");

            if (ChoiceAlert.instance.resultingDecision)
            {
                player.AdjustBalanceBy(-purchasePrice);
                ownedBy = player;
            }
        }
    }
}
