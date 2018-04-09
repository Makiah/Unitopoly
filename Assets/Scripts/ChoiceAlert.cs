using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceAlert : MonoBehaviour
{
    public static ChoiceAlert instance;
    void Awake()
    {
        instance = this;
    }

    [SerializeField] private Text choiceDialog;
    [SerializeField] private Button affirmative, negative;
    [SerializeField] private Text affirmativeText, negativeText;
    [HideInInspector] public bool decisionMade = false, resultingDecision = false;

    public IEnumerator CreateChoiceAlert(string message, Color affirmativeColor, string affirmativeText, Color negativeColor, string negativeText)
    {
        decisionMade = false;
        resultingDecision = false;
        
        // Initialize UI elements.  
        choiceDialog.text = message;
        this.affirmativeText.text = affirmativeText;
        this.negativeText.text = negativeText;
        this.affirmative.gameObject.GetComponent<Image>().color = affirmativeColor;
        this.negative.gameObject.GetComponent<Image>().color = negativeColor;
        
        transform.GetChild(0).gameObject.SetActive(true);

        while (!decisionMade)
            yield return null;
        
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Affirmative()
    {
        resultingDecision = true;
        decisionMade = true;
    }

    public void Negative()
    {
        resultingDecision = false;
        decisionMade = true;
    }
}
