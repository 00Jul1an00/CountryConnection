using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class Money : MonoBehaviour
{
    [SerializeField] private PassiveIncome _localPassiveIncome;
    [SerializeField] private Town[] _townArray;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private GameObject _parentTown;
    private int _townCount;
    public static float PlayerMoney { get; private set; } = 1000;
  
    private void Start()
    {
        _townCount = _parentTown.transform.childCount;
        _townArray = new Town[_townCount];
        for (int i = 0; i < _townCount; i++)
        {
            _townArray[i] = _parentTown.
            _townArray[i].MoneyChanged += OnMoneyChanged;
        }
        _localPassiveIncome.MoneyChanged += OnMoneyChanged;
        OnMoneyChanged(PlayerMoney);
    }

    private void OnDisable()
    {
        _localPassiveIncome.MoneyChanged -= OnMoneyChanged;
        for (int i = 0; i < _townArray.Length; i++)
        {
            _townArray[i].MoneyChanged -= OnMoneyChanged;
        }
    }
    private void OnMoneyChanged(float money)
    {
        PlayerMoney = money;
       _moneyText.text = PlayerMoney.ToString();
    }
}
