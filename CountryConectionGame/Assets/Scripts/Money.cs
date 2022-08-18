using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class Money : MonoBehaviour
{
    [SerializeField] private PassiveIncome _localPassiveIncome;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private LocationManager _locationManager;
    public static float PlayerMoney { get; private set; }
  
    private void Start()
    {
        _localPassiveIncome.MoneyChanged += OnMoneyChanged;
        OnMoneyChanged(PlayerMoney);
    }

    private void OnEnable()
    {
        _locationManager.TownListSubscriber(OnMoneyChanged);
        _locationManager.RegionListSubscriber(OnMoneyChanged);
    }
    private void OnDisable()
    {
        _locationManager.TownListUnsubscriber(OnMoneyChanged);
        _locationManager.RegionListUnsubscriber(OnMoneyChanged);
        _localPassiveIncome.MoneyChanged -= OnMoneyChanged;
    }
    private void OnMoneyChanged(float money)
    {
        PlayerMoney += money;
       _moneyText.text = PlayerMoney.ToString();
    }




}
