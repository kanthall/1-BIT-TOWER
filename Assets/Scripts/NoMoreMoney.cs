using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoMoreMoney : MonoBehaviour
{
    [SerializeField] public Text noMoneyText1;
    [SerializeField] public Text noMoneyText2;
    [SerializeField] public Image noMoneyTextImage;

    private void Start()
    {
        noMoneyText1.enabled = false;
        noMoneyText2.enabled = false;
        noMoneyTextImage.enabled = false;
    }
}