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


    private void Start()
    {

    }
    private void OnMouseDown()
    {
        _upgradePanel.SetActive(true);
    }

    private void ClosePanel()
    {
        
    }

}
    

