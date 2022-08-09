using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private Vector2 _originVector;
    private Vector2 _endVector;
    private bool _isConnected;
    private Town _startTown;
    private Town _endTown;

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
                    _isConnected = (t == _startTown || t == _endTown);
                    Debug.Log(_isConnected);
                }

            }
        }
        _endTown = null;
        _startTown = null;
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
                    town = t;
                    return true;
                }
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_originVector, _endVector - _originVector);
    }
}
