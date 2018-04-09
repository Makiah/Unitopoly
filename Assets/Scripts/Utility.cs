using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Utility : BoardLocation
{
	[SerializeField] private string utilityName;
	[SerializeField] private int purchasePrice;
	[SerializeField] private Utility otherUtility;
	private Player ownedBy;
	
	public override void PassBy(Player player)
	{
	}

	protected override IEnumerator PropertySpecificActions(Player player)
	{
		if (ownedBy == null)
		{
			yield return ChoiceAlert.instance.CreateChoiceAlert("Buy " + utilityName + "?",
				Color.green, "M" + purchasePrice, Color.yellow, "Nope");

			if (ChoiceAlert.instance.resultingDecision)
			{
				player.AdjustBalanceBy(-purchasePrice);
				ownedBy = player;
			}
		}
		else
		{
			if (ownedBy != player)
			{
				int toCharge = DieRoller.instance.GetDieRollResults().Sum();
				if (otherUtility.ownedBy == ownedBy)
					toCharge *= 10;
				else
					toCharge *= 4;

				yield return MessageAlert.instance.DisplayAlert("Uh oh, you have to pay M" + toCharge, Color.red);
			}
			else
			{
				yield return MessageAlert.instance.DisplayAlert("You own this utility!", Color.blue);
			}
		}
	}
}
