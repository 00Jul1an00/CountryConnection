using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    private Vector2 _originVector;
    private Vector2 _endVector;
    private Town _startTown;
    private Town _endTown;

    //Dubug
    private Dictionary<Town, Town> _connectedTowns = new Dictionary<Town, Town>(10);

    public event UnityAction<Vector2, Vector2> PathIsBuilt;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RoadBuilder(Input.GetMouseButtonDown, 0, ray, ref _startTown, ref _originVector);

        if(RoadBuilder(Input.GetMouseButtonUp, 0, ray, ref _endTown, ref _endVector))
        {
            Ray checkCollisionRay = new Ray(_originVector, _endVector - _originVector);
            float distance = Vector2.Distance(_endVector, _originVector);

            if (Physics.Raycast(checkCollisionRay, out var hitInfo, distance))
            {
                if (hitInfo.collider.TryGetComponent(out Town t))
                {
                    if (t == _startTown || t == _endTown)
                    {
                        if(_connectedTowns.TryAdd(_startTown, _endTown))
                        {
                            print(_connectedTowns.Count);
                            PathIsBuilt?.Invoke(_originVector, _endVector);
                        }
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
