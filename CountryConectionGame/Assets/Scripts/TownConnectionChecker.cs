using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownConnectionChecker : MonoBehaviour
{
    [SerializeField] private List<Town> _towns = new List<Town>();
    [SerializeField] private Raycaster _raycaster;

    private List<bool> _connections = new List<bool>();

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        _raycaster.TryConnect += OnTryConnect;
    }

    private void OnDisable()
    {
        _raycaster.TryConnect -= OnTryConnect;
    }

    private void Update()
    {
        
    }

    public void OnTryConnect(Town startTown, Town endTown)
    {

    }
}
