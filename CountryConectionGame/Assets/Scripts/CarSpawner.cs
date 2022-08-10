using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Car _carPrefab;

    private void OnEnable()
    {
        _raycaster.PathIsBuilt += OnPathIsBuilt;
    }

    private void OnDisable()
    {
        _raycaster.PathIsBuilt -= OnPathIsBuilt;
    }

    private void OnPathIsBuilt(Vector2 startPos, Vector2 endPos)
    {
        Car carInstance = Instantiate(_carPrefab, startPos, Quaternion.identity);
        carInstance.Init(startPos, endPos);
    }
}
