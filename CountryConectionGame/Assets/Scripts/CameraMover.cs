using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _camereMovingSpeed;

    private Vector3 _startPos;
    private float _targetPosX;
    private float _targetPosY;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
        } 
        else if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(!Physics.Raycast(ray, Mathf.Infinity, 6) && !PathBuilder.StartingBuildPath)
            {
                Vector3 pos = ray.origin.normalized - _startPos;

                _targetPosX = transform.position.x - pos.x;
                _targetPosY = transform.position.y - pos.y;

                //transform.position = new Vector3(transform.position.x - pos.x, transform.position.y - pos.y, transform.position.z);
            }
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, _targetPosX, _camereMovingSpeed * Time.deltaTime),
                                         Mathf.Lerp(transform.position.y, _targetPosY, _camereMovingSpeed * Time.deltaTime),
                                         transform.position.z);
    }
}
