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
    [SerializeField] private TMP_Text _moneyText;
    public static float PlayerMoney { get; private set; } = 1000;
  
    private void Start()
    {
        _localPassiveIncome.MoneyChanged += OnMoneyChanged;
        _localTown.MoneyChanged += OnMoneyChanged;
        OnMoneyChanged(PlayerMoney);
    }

    private void OnDisable()
    {
        _localPassiveIncome.MoneyChanged -= OnMoneyChanged;
    }
    private void OnMoneyChanged(float money)
    {
        PlayerMoney = money;
       _moneyText.text = PlayerMoney.ToString();
    }
}
