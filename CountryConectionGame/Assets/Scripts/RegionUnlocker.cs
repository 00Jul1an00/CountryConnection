using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RegionUnlocker : MonoBehaviour
{
    [SerializeField] private List<Town> _townsInRegion;
    [SerializeField] private GameObject _lockPanel;
    [SerializeField] private int price;

    private float _playerMoney;

    public UnityAction<float> MoneyChanged;

    private void Start()
    {
        _playerMoney = Money.PlayerMoney;

        foreach (Town town in _townsInRegion)
            town.gameObject.SetActive(false);
    }

    public void OnRegionUnlockButtonClick()
    {
        if (_playerMoney > price)
        {
            _playerMoney -= price;
            MoneyChanged?.Invoke(_playerMoney);

            _lockPanel.SetActive(false);

            foreach (Town town in _townsInRegion)
                town.gameObject.SetActive(true);
        }
        else
            print("no money???");

        print(_playerMoney);
    }
}
