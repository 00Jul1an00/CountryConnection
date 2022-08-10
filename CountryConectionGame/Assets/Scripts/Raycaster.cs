using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Зарефакторить и разбить по разным скриптам
public class Raycaster : MonoBehaviour
{
    private Vector2 _originVector;
    private Vector2 _endVector;
    private Town _startTown;
    private Town _endTown;

    public event UnityAction<Vector2, Vector2> PathIsBuilt;
    public event UnityAction<Town, Town> TryConnect;

    private List<Vector2> _blockedPaths = new List<Vector2>();

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RoadBuilder(Input.GetMouseButtonDown, 0, ray, ref _startTown, ref _originVector);

        if(RoadBuilder(Input.GetMouseButtonUp, 0, ray, ref _endTown, ref _endVector))
        {
            Vector2 path = _originVector + _endVector;

            if (_blockedPaths.Contains(path))
            {
                print("this path already exist");
                return;
            }

            Ray checkCollisionRay = new Ray(_originVector, _endVector - _originVector);
            float distance = Vector2.Distance(_endVector, _originVector);

            if (Physics.Raycast(checkCollisionRay, out var hitInfo, distance))
            {
                if (hitInfo.collider.TryGetComponent(out Town t))
                {
                    if (t == _startTown || t == _endTown)
                    {
                        PathIsBuilt?.Invoke(_originVector, _endVector);
                        _blockedPaths.Add(path);
                    }
                }
            }
        }
    }
                        
    private bool RoadBuilder(Func<int, bool> f, int T, Ray ray, ref Town town, ref Vector2 vector)
    {
        if(f(T))
        {
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.TryGetComponent(out Town t))
                {
                    vector = hit.transform.position;
                    //print(vector);
                    town = t;
                    return true;
                }
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawRay(_originVector, _endVector - _originVector);
        Gizmos.DrawLine(_originVector, _endVector);
    }
}
