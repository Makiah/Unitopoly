using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyPurchaser : MonoBehaviour
{
    public static PropertyPurchaser instance;
    [SerializeField] private Text purchaseDialog;

    void Awake()
    {
        instance = this;
    }

    [HideInInspector] public bool purchaseDecided = false, purchaseDecision = false;

    public IEnumerator SuggestNewPurchase(Player luckyRecipient, Property property)
    {
        purchaseDecided = false;
        purchaseDecision = false;
        
        transform.GetChild(0).gameObject.SetActive(true);

        purchaseDialog.text = "Would you like to purchase " + property.propertyName + " for M" + property.propertyPurchasePrice + "?";

        while (!purchaseDecided)
            yield return null;
        
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Purchase()
    {
        purchaseDecision = true;
        purchaseDecided = true;
    }

    public void Auction()
    {
        throw new System.NotImplementedException();

        purchaseDecision = false;
        purchaseDecided = true;
    }
}
