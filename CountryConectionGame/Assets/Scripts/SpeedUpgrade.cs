using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpgrade : MonoBehaviour
{
    [SerializeField] private Button _upgradeSpeedButton;
    private float _additionalSpeed = 0;
    private int _upgradeCost = 100;
    private int _upgradeCount = 0;

    public void ButtonClick()
    {
         if (Money.PlayerMoney >= _upgradeCost)
         {
            Money.MoneySetter(-_upgradeCost, this);
            _upgradeCount++;
            _upgradeCost += 300 * _upgradeCount;
           _additionalSpeed += 0.05f;
           Car.SpeedSetter(_additionalSpeed, this);
         }
         else
         { 
           print("У вас недостаточно средств!");
         }
    }

}
