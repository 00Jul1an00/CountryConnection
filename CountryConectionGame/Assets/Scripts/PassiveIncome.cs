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
    private float _localMoney;

    public event UnityAction<float> OnMoneyChanged;

    void Start()
    {
        StartCoroutine(IncomePerSec());
        _localMoney = Money._money;
    }

    
    public void Purchase()
    {      
        if (_localMoney >= _price)
        {
            _localMoney -= _price;
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
            _localMoney += _bonus * _purchaseQuantity;
            OnMoneyChanged?.Invoke(_localMoney);
            yield return new WaitForSeconds(1);
        }
    }
}
