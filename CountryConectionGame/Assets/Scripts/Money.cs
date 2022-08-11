using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class Money : MonoBehaviour
{
    
    [SerializeField] protected TMP_Text _moneyText;
    protected float _money = 1000;

    public UnityAction<float> OnMoneyChanged;

    private void Start()
    {
       
    }
    protected void MoneyChanged(float money)
    {       
       _moneyText.text = money.ToString();
    }
}
