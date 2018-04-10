using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceTracker : MonoBehaviour
{
    private Text balanceField, nameField;

    void Awake()
    {
        balanceField = transform.Find("Text").GetComponent<Text>();
        nameField = transform.Find("Panel").Find("Text").GetComponent<Text>();
    }

    public void UpdateBalance(int balance)
    {
        this.balanceField.text = "" + balance;
    }

    public void UpdateName(string newName)
    {
        nameField.text = newName;
    }
}
