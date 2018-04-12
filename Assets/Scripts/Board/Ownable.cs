using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ownable : BoardLocation
{   
    protected Player owner;

    [SerializeField] private string propertyName;
    [SerializeField] private int purchasePrice;
    [SerializeField] private int mortgageValue;
    [SerializeField] public Sprite deed;
    
    public sealed override void PassBy(Player player)
    {}

    public sealed override IEnumerator LandOn(Player player)
    {
        if (owner == null)
        {
            if (!player.IsAI())
            {
                yield return LerpCameraViewToThisLocation();
                yield return OwnablePurchaseDialog.instance.OfferPurchase(this);

                if (OwnablePurchaseDialog.instance.resultingDecision)
                {
                    player.AdjustBalanceBy(-purchasePrice);
                    player.currentOwnables.Add(this);
                    owner = player;
                }

                yield return LerpCameraViewBackToMainBoardView();
            }
            else
            {
                // TODO more complex AI logic.  
                player.AdjustBalanceBy(-purchasePrice);
                player.currentOwnables.Add(this);
                owner = player;
            }
        }
        else
        {
            if (owner != player)
            {
                int toCharge = ChargePlayer();
                player.AdjustBalanceBy(-toCharge);
                owner.AdjustBalanceBy(toCharge);
            }
        }
    }

    protected abstract int ChargePlayer();
}
