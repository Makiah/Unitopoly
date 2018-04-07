using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceTracker : MonoBehaviour
{
    private Text text;

    void Awake()
    {
        text = transform.Find("Text").GetComponent<Text>();
    }

    public void UpdateBalance(int balance)
    {
        this.text.text = "" + balance;
    }
}
