using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _linePrefab;
    [SerializeField] private Raycaster _raycaster;

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

        if (Input.GetMouseButton(0)) _lineRenderer.SetPosition(1, _mousePos);

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
