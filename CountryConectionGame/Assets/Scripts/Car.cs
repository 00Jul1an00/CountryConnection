using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Car : MonoBehaviour
{
    [SerializeField] private static float _speed = 0.4f;
    [SerializeField] private int _income;

    private float _distance = 0;
    private Vector2 _startAnimPoint;
    private Vector2 _endAnimPoint;
    private bool _isReachedTown = false;

    public int Income => _income;

    public void Init(Vector2 _startPoint, Vector2 _endPoint)
    {
        _startAnimPoint = _startPoint;
        _endAnimPoint = _endPoint;
    }

    private void Update()
    {
        if (_distance >= 1)
            _isReachedTown = true;
        else if (_distance <= 0.01)
            _isReachedTown = false;

        if (_isReachedTown)
            _distance -= Time.deltaTime * _speed;
        else
            _distance += Time.deltaTime * _speed;


        transform.position = Vector2.Lerp(_startAnimPoint, _endAnimPoint, _distance);
    }

    public static void SpeedSetter(float adSpeed, object objectChanger)
    {
        if (objectChanger is SpeedUpgrade)
       {
           _speed += adSpeed;
        }
        else
       {
            throw new Exception("???????");
       }
    }
}
