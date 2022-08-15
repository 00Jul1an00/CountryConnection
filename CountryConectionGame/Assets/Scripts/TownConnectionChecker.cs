using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownConnectionChecker : MonoBehaviour
{
    [SerializeField] private List<Town> _towns = new List<Town>();
    [SerializeField] private PathBuilder _raycaster;

    private List<bool> _connections = new List<bool>();

    private void Start()
    {
    }

    private void OnEnable()
    {   
    }

    private void OnDisable()
    {
    }


    private void Update()
    {

    }

    

    public void OnTryConnect(Town startTown, Town endTown)
    {

    }
}
