using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class LocationManager : MonoBehaviour
{
    private Town[] _townsList;
    private RegionUnlocker[] _regionsList;
    
    void Awake()
    {
        _townsList = FindObjectsOfType<Town>();
        _regionsList = FindObjectsOfType<RegionUnlocker>();
    }

    public void TownListSubscriber(UnityAction<float> f)
    {
        foreach (Town town in _townsList)
        {
            town.MoneyChanged += f;
        }
    }

    public void RegionListSubscriber(UnityAction<float> f)
    {
        foreach (RegionUnlocker region in _regionsList)
        {
            region.MoneyChanged += f;   
        }
    }

    public void TownListUnsubscriber(UnityAction<float> f)
    {
        foreach (Town town in _townsList)
        {
            town.MoneyChanged -= f;
        }
    }

    public void RegionListUnsubscriber(UnityAction<float> f)
    {
        foreach (RegionUnlocker region in _regionsList)
        {
            region.MoneyChanged -= f;
        }
    }

}
