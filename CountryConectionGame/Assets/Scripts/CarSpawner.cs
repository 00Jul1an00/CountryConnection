using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private PathBuilder _raycaster;
    [SerializeField] private Car _carPrefab;

    private void OnEnable() => _raycaster.PathIsBuilt += OnPathIsBuilt;

    private void OnDisable() => _raycaster.PathIsBuilt -= OnPathIsBuilt;

    private void OnPathIsBuilt(Vector2 startPos, Vector2 endPos)
    {
        Vector2 lookDir = startPos - endPos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        Car carInstance = Instantiate(_carPrefab, startPos, rotation, transform);
        carInstance.Init(startPos, endPos);
    }
}
