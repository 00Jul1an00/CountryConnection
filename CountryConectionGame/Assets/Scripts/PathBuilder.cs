using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PathBuilder : MonoBehaviour
{
    private Vector2 _startTownPosition;
    private Vector2 _endTownPosition;
    private Vector2 _path;
    private Town _startTown;
    private Town _endTown;

    public bool CanBuildPath { get; private set; } = false;

    public event UnityAction<Vector2, Vector2> PathIsBuilt;
    public event UnityAction<Vector2> FirstTownPositionGeted;
    public event UnityAction<Vector2> LastTownPositionGeted;

    private List<Vector2> _blockedPaths = new List<Vector2>();

    private void Update()
    {
        if (RoadBuilder(Input.GetMouseButtonDown, ref _startTown, ref _startTownPosition))
        {
            FirstTownPositionGeted?.Invoke(_startTownPosition);
        }

        if (RoadBuilder(Input.GetMouseButton, ref _endTown, ref _endTownPosition))
        {
            _path = _startTownPosition + _endTownPosition;

            if (_blockedPaths.Contains(_path))
                return;

            Ray checkCollisionRay = new Ray(_startTownPosition, _endTownPosition - _startTownPosition);
            float distance = Vector2.Distance(_endTownPosition, _startTownPosition);

            if (Physics.Raycast(checkCollisionRay, out var hitInfo, distance))
            {
                if (hitInfo.collider.TryGetComponent(out Town t))
                {
                    if (t == _startTown || t == _endTown)
                    {
                        CanBuildPath = true;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && CanBuildPath)
        {
            LastTownPositionGeted?.Invoke(_endTownPosition);
            PathIsBuilt?.Invoke(_startTownPosition, _endTownPosition);
            _blockedPaths.Add(_path);
        }
    }
                        
    private bool RoadBuilder(Func<int, bool> f, ref Town town, ref Vector2 vector, int numInFunc = 0)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (f(numInFunc))
        {
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.TryGetComponent(out Town t))
                {
                    vector = hit.transform.position;
                    town = t;
                    return true;
                }
            }
            else
            {
                CanBuildPath = false;
            }
        }
        return false;
    }
}
