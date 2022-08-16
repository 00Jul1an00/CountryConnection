using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionUnlocker : MonoBehaviour
{
    private float _playerMoney;

    private void Start()
    {
        _playerMoney = Money.PlayerMoney;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnRegionUnlockButtonClick()
    {

    }
}
