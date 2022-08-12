using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Town : MonoBehaviour
{
    private int _townGrade = 1;
    private int _gradeCost;
    private GameObject _panel;
    private void OnMouseUpAsButton()
    {
        
    }

    private void OpenPanel()
    {
        if (_panel != null)
        {
            bool isActive = _panel.activeSelf;
        }
    }
}
