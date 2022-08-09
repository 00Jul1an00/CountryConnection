using UnityEngine;

/// <summary>
/// Œ“–≈‘¿ “Œ–»“‹
/// </summary>
/// 
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

        if (Input.GetMouseButtonDown(0))
        { 
            if(Physics.Raycast(ray, out var hit))
            {
                if(hit.collider.TryGetComponent(out Town town))
                {
                    _originVector = hit.transform.position;
                    _startTown = town;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.TryGetComponent(out Town town))
                {
                    _endTown = town;
                    _endVector = hit.transform.position;
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
            }
        }

        _endTown = null;
        _startTown = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_originVector, _endVector - _originVector);
    }
}
