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
    [SerializeField] private GameObject _parent;
    private Canvas _upgradeCanvas;
    
    private int _townGrade = 1;
    private int _currentGrade;
    private int _gradeCost = 100;
    private int _currentCost;
    private static float _localMoney;

    //private void Start()
    //{
    //    _upgradeCanvas = _parent.transform.GetChild(2).GetComponent<Canvas>();
    //    _upgradeCanvas.overrideSorting = true;
    //}

    private void FixedUpdate()
    {
        _upgradeCanvas.overrideSorting = true;
    }
    private void OnEnable()
    {
        _upgradeCanvas = _parent.transform.GetChild(2).GetComponent<Canvas>();
        _upgradeCanvas.overrideSorting = true;
        print(_upgradeCanvas.name);
        print(_upgradeCanvas.overrideSorting);
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
        if (Money.PlayerMoney >= _gradeCost)
        {           
            Money.MoneySetter(-_gradeCost, this);
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
            Money.MoneySetter(car.Income, this);
        }
    }
}
    

