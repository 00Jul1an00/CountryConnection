using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PassiveIncome : Money
{

    
    [SerializeField] private Button _passiveIncomeButton;
    private int _purchaseQuantity = 0;
    private int _bonus = 10;
    private int _price = 100;

    public event UnityAction<float> OnMoneyChanged;

    void Start()
    {
        StartCoroutine(IncomePerSec());       
    }

    
    public void Purchase()
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
        while (true)
        {
            _money += _bonus * _purchaseQuantity;
            OnMoneyChanged?.Invoke(_money);
            yield return new WaitForSeconds(1);
        }
    }
}
