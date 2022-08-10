using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class Money : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _moneyText;
    protected float _money = 0;

    private UnityEvent<float> OnMoneyChanged;

   
    private void MoneyChanged()
    {       
        OnMoneyChanged?.Invoke(_money);
        _moneyText.text = _money.ToString();
    }
}
