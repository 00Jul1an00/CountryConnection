using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _camereMovingSpeed;
    [SerializeField] private float _zoomSpeed;

    private Vector3 _startPos;
    private float _targetPosX;
    private float _targetPosY;
    private Camera _cam;

    private void Start() => _cam = GetComponent<Camera>();

    private void Update()
    {
        CameraZoomCheck();
        ChangeCameraZoom(Input.mouseScrollDelta.y < 0, Input.mouseScrollDelta.y > 0, 1f);

        if (Input.GetMouseButtonDown(1))
        {
            _startPos = _cam.ScreenToWorldPoint(Input.mousePosition);
        } 
        else if(Input.GetMouseButton(1))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            
            if(!Physics.Raycast(ray, Mathf.Infinity, 6) && !PathBuilder.StartingBuildPath)
            {
                Vector3 pos = _cam.ScreenToWorldPoint(Input.mousePosition) - _startPos;

                _targetPosX = transform.position.x - pos.x;
                _targetPosY = transform.position.y - pos.y;
            }
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, _targetPosX, _camereMovingSpeed * Time.deltaTime),
                                         Mathf.Lerp(transform.position.y, _targetPosY, _camereMovingSpeed * Time.deltaTime),
                                         transform.position.z);
    }

    private void CameraZoomCheck()
    {
        if (_cam.orthographicSize <= 3)
            _cam.orthographicSize = 3;
        else if (_cam.orthographicSize >= 15)
            _cam.orthographicSize = 15;
    }

    private void ChangeCameraZoom(bool FirstCondition, bool SecondCondition, float size)
    {
        if(FirstCondition)
            _cam.orthographicSize += size * Time.deltaTime * _zoomSpeed;
        else if(SecondCondition)
            _cam.orthographicSize -= size * Time.deltaTime * _zoomSpeed;

    }
}
