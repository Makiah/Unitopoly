using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnablePurchaseDialog : MonoBehaviour
{
    public static OwnablePurchaseDialog instance;
    void Awake()
    {
        instance = this;
    }

    [SerializeField] private Image deedImage;

    [HideInInspector] public bool decisionMade, resultingDecision;

    public IEnumerator OfferPurchase(Ownable ownable)
    {
        decisionMade = false;
        
        deedImage.sprite = ownable.deed;
        transform.GetChild(0).gameObject.SetActive(true);

        while (!decisionMade)
            yield return null;
        
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Buy()
    {
        resultingDecision = true;
        decisionMade = true;
    }

    public void Auction()
    {
        resultingDecision = false;
        decisionMade = true;
    }
}
