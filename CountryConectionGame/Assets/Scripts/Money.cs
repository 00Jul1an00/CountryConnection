using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;


public class Money : MonoBehaviour
{
    [SerializeField] private PassiveIncome _localPassiveIncome;
    private static TMP_Text _moneyText;    
    public static float PlayerMoney { get; private set; }

    private void Start()
    {
        _moneyText = GetComponent<TMP_Text>();
    }
    public static void MoneySetter(float money, object objectChanger)
    {
        if (objectChanger is PassiveIncome)
        {
            PlayerMoney += money;
        }
        else if (objectChanger is Town)
        {
            PlayerMoney += money;
        }
        else if (objectChanger is RegionUnlocker)
        {
            PlayerMoney += money;
        }
        else if (objectChanger is SpeedUpgrade)
        {
            PlayerMoney += money;
        }
        else
        {
            throw new Exception("пидарас");
        }

        _moneyText.text = PlayerMoney.ToString();
    }
   
    
    




}
