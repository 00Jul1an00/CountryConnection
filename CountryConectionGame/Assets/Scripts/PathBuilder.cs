using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Зарефакторить и разбить по разным скриптам
public class PathBuilder : MonoBehaviour
{
    private Vector2 _startTownPosition;
    private Vector2 _endTownPosition;
    private Town _startTown;
    private Town _endTown;
    private Ray checkCollisionRay;
    private float distance;
    private Vector2 path;


    public event UnityAction<Vector2, Vector2> PathIsBuilt;
    public event UnityAction<Vector2> FirstTownPositionGeted;
    public event UnityAction<Vector2> LastTownPositionGeted;
    public event UnityAction PathIsReadyToBuild;

    private List<Vector2> _blockedPaths = new List<Vector2>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && RoadBuilder(ref _startTown, ref _startTownPosition))
        {
            FirstTownPositionGeted?.Invoke(_startTownPosition);
        }

        if (Input.GetMouseButton(0) && (RoadBuilder(ref _endTown, ref _endTownPosition)))
        {
            path = _startTownPosition + _endTownPosition;

            if (_blockedPaths.Contains(path))
            {
                print("this path already exist");
                return;
            }

            checkCollisionRay = new Ray(_startTownPosition, _endTownPosition - _startTownPosition);
            distance = Vector2.Distance(_endTownPosition, _startTownPosition);
        }

        if (Physics.Raycast(checkCollisionRay, out var hitInfo, distance))
        {
            if (hitInfo.collider.TryGetComponent(out Town t))
            {
                if (t == _startTown || t == _endTown)
                {
                    PathIsReadyToBuild?.Invoke();
                    if(Input.GetMouseButtonUp(0))
                    {
                        LastTownPositionGeted?.Invoke(_endTownPosition);
                        PathIsBuilt?.Invoke(_startTownPosition, _endTownPosition);
                        _blockedPaths.Add(path);
                    }
                }
            }
        }
    }
                        
    private bool RoadBuilder(ref Town town, ref Vector2 vector)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.TryGetComponent(out Town t))
            {
                vector = hit.transform.position;
                town = t;
                return true;
            }
        }
        return false;
    }
}
