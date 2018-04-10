using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnActions : MonoBehaviour
{
    public static TurnActions instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField] private Text rollText;
    
    public enum UserAction {ROLL, TRADE, MORTGAGE, BUILD, UNDECIDED}
    private UserAction chosenAction = UserAction.UNDECIDED;
    public UserAction GetChosenAction()
    {
        return chosenAction;
    }

    public IEnumerator GetUserInput(bool enableRoll)
    {
        chosenAction = UserAction.UNDECIDED;
        
        transform.GetChild(0).gameObject.SetActive(true);
        rollText.text = enableRoll ? "ROLL" : "End Turn";

        while (chosenAction == UserAction.UNDECIDED)
            yield return null;
        
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Roll()
    {
        chosenAction = UserAction.ROLL;
    }

    public void Trade()
    {
        chosenAction = UserAction.TRADE;
    }

    public void Mortgage()
    {
        chosenAction = UserAction.MORTGAGE;
    }

    public void Build()
    {
        chosenAction = UserAction.BUILD;
    }
}
