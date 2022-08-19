using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RegionUnlocker : MonoBehaviour
{
    [SerializeField] private List<Town> _townsInRegion;
    [SerializeField] private GameObject _lockPanel;
    [SerializeField] private int _price;
    
    private void Awake()
    {        
        foreach (Town town in _townsInRegion)
            town.gameObject.SetActive(false);
    }

    public void OnRegionUnlockButtonClick()
    {
        if (Money.PlayerMoney >= _price)
        {
            Money.MoneySetter(-_price, this);

            //_lockPanel.SetActive(false);
            Destroy(_lockPanel);

            foreach (Town town in _townsInRegion)
                town.gameObject.SetActive(true);
        }
        else
            print("no money???");

        print(Money.PlayerMoney);
    }
}
