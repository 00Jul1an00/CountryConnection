using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveIncome : Money
{
    private int _purchaseQuantity = 0;
    private int _bonus = 10;
    private int _price = 100;
    void Start()
    {
        StartCoroutine(IncomePerSec());
    }

    private void Purchase()
    {
        if (_money >= _price)
        {
            _money -= _price;
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
        _money += _bonus * _purchaseQuantity;
        yield return new WaitForSeconds(1);
    }
}
