using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PassiveIncome : MonoBehaviour
{

    [SerializeField] private Button _passiveIncomeButton;   
    private int _purchaseQuantity = 0;
    private int _bonus = 10;
    private int _price = 100;
  
    public void Purchase()
    {      
        if (_purchaseQuantity == 1)
            StartCoroutine(IncomePerSec());

        if (Money.PlayerMoney >= _price)
        {            
            Money.MoneySetter(-_price, this);
            _purchaseQuantity++;
            _price *= 2;           
        }
        else
        {
            Debug.Log("У вас недостаточно средств!");
        }
    }

    IEnumerator IncomePerSec()
    {
        while (true)
        {            
            Money.MoneySetter(_bonus * _purchaseQuantity, this);
            yield return new WaitForSeconds(1);
        }
    }
}
