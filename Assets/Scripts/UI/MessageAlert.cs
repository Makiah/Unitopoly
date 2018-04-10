using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageAlert : MonoBehaviour
{
    public static MessageAlert instance;
    void Awake()
    {
        instance = this;
    }

    [SerializeField] private Text displayText;
    [SerializeField] private Button okButton;
    private bool userSaidOK = false;

    public IEnumerator DisplayAlert(string alert, Color okColor)
    {
        okButton.gameObject.GetComponent<Image>().color = okColor;
        displayText.text = alert;
        transform.GetChild(0).gameObject.SetActive(true);
        
        while (!userSaidOK)
            yield return null;
        
        transform.GetChild(0).gameObject.SetActive(false);
        userSaidOK = false;
    }

    public void UserOK()
    {
        userSaidOK = true;
    }
}
