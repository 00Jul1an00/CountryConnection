using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _linePrefab;
    [SerializeField] private PathBuilder _raycaster;

    private LineRenderer _lineRenderer;
    private Vector2 _startPos;
    private Vector2 _mousePos;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            ChangeLineColor();
            _lineRenderer.SetPosition(1, _mousePos);
        }

        if (Input.GetMouseButtonUp(0)) _lineRenderer.enabled = false;
    }

    private void OnEnable()
    {
        _raycaster.FirstTownPositionGeted += OnFirstTownPositionGeted;
        _raycaster.LastTownPositionGeted += OnLastTownPositionGeted;
    }

    private void OnDisable()
    {
        _raycaster.FirstTownPositionGeted -= OnFirstTownPositionGeted;
        _raycaster.LastTownPositionGeted -= OnLastTownPositionGeted;
    }

    private void ChangeLineColor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.TryGetComponent(out Town t))
            {
                _lineRenderer.startColor = Color.blue;
                _lineRenderer.endColor = Color.blue;
            }
        }
        else
        {
            _lineRenderer.startColor = Color.red;
            _lineRenderer.endColor = Color.red;
        }
    }

    private void OnFirstTownPositionGeted(Vector2 pos)
    {
        _lineRenderer.enabled = true;
        _startPos = pos;
        _lineRenderer.SetPosition(0, _startPos);
    }

    private void OnLastTownPositionGeted(Vector2 pos)
    {
        LineRenderer line = Instantiate(_linePrefab, _startPos, Quaternion.identity, transform);
        line.SetPosition(0, _startPos);
        line.SetPosition(1, pos);
    }
}
