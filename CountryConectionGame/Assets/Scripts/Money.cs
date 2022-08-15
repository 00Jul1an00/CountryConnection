using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class Money : MonoBehaviour
{
    [SerializeField] private PassiveIncome _localPassiveIncome;
    [SerializeField] private Town _localTown;
    [SerializeField] protected TMP_Text _moneyText;
    public static float _money { get; private set; } = 1000;
  
    private void Start()
    {
        _localPassiveIncome.OnMoneyChanged += MoneyChanged;
        _localTown.OnMoneyChanged += MoneyChanged;
        MoneyChanged(_money);
    }

    private void OnDisable()
    {
        _localPassiveIncome.OnMoneyChanged -= MoneyChanged;
    }
    private void MoneyChanged(float money)
    {
        _money = money;
       _moneyText.text = _money.ToString();
    }
}
