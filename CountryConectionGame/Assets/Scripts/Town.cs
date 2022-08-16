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
    [SerializeField] private GameObject _parentTown;

    private int _townGrade = 1;
    private int _currentGrade;
    private int _gradeCost = 100;
    private int _currentCost;
    private static float _localMoney;

    public event UnityAction<float> MoneyChanged;

    private void Start()
    {
        _localMoney = Money.PlayerMoney;      
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

    public void UpgradeClick()
    {
        if (_localMoney >= _gradeCost)
        {
            _localMoney -= _gradeCost;
            MoneyChanged?.Invoke(_localMoney);
            _gradeCost += (_gradeCost * _townGrade + 1);
            _townGrade++;
        }
        else
        {
            Debug.Log("У вас недостаточно средств!");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Car car))
        {
            _localMoney += car.Income;
            MoneyChanged?.Invoke(_localMoney);
            print(_localMoney);
        }
    }
}
    

