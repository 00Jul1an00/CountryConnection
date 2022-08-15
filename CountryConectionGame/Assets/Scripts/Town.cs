using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Town : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private Button _upgradeButton;   
    private int _townGrade = 1;
    private int _currentGrade;
    private int _gradeCost = 100;
    private int _currentCost;
    private float _localMoney;

    public event UnityAction<float> OnMoneyChanged;
    private void Start()
    {
        _localMoney = Money._money;
        
    }
    private void OnMouseUpAsButton()
    {        
        _upgradePanel.SetActive(true);
    }

    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(3);
        _upgradePanel.SetActive(false);
    }

    private void OnMouseExit()
    {
        StartCoroutine(ClosePanel());
    }

    public void _upgradeClick()
    {
        if (_localMoney >= _gradeCost)
        {
            _localMoney -= _gradeCost;
            OnMoneyChanged?.Invoke(_localMoney);
            _gradeCost += (_gradeCost * _townGrade + 1);
            _townGrade++;
        }
        else
        {
            Debug.Log("У вас недостаточно средств!");
        }
    }
}
    

