using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private Vector2 _originVector;
    private Vector2 _endVector;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit))
            {
                if(hit.collider.TryGetComponent(out Town town))
                {
                    _originVector = hit.transform.position;
                    print(_originVector.x + " " + _originVector.y);
                    if(Input.GetMouseButtonUp(0))
                    {
                        _endVector = hit.transform.position;
                        print(_endVector.x + " " + _endVector.y);
                        float finalVector = Vector2.Distance(_originVector, _endVector);
                        print(finalVector);
                    }
                }
            }
        }
    }
}
