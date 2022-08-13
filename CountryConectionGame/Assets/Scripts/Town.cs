using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Town : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;

    private int _townGrade;
    private int _currentGrade;
    private int _gradeCost;
    private int _currentCost;


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
}
    

