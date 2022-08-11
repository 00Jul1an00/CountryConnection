using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class Money : MonoBehaviour
{
    [SerializeField] private PassiveIncome _local;
    [SerializeField] protected TMP_Text _moneyText;
    protected float _money = 1000;
  
    private void Start()
    {
        _local.OnMoneyChanged += MoneyChanged;
        MoneyChanged(_money);
    }

    private void OnDisable()
    {
        _local.OnMoneyChanged -= MoneyChanged;
    }
    protected void MoneyChanged(float money)
    {       
       _moneyText.text = money.ToString();
    }
}
